using System.Collections.Concurrent;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;

namespace AssetDownload
{
    public class ResDownload
    {
        private readonly string _host;
        private readonly string _outDir;
        private readonly string? _proxy;

        public ResDownload(string outDir, string? host, string? proxy = null)
        {
            _host = host ?? "http://mirfiles.com/resources/mir2/crystal/patch/";
            _outDir = outDir;
            _proxy = proxy;
        }

        public void DownloadAll()
        {
            var taskCount = Math.Max(10, Environment.ProcessorCount * 2);
            Task.WaitAll(AsyncDownloadAll(taskCount));
            Console.Write("完成下载，按任意键退出...");
            Console.ReadKey(true);
        }

        private async Task AsyncDownloadAll(int taskCount)
        {
            var gzUrl = _host + "PList.gz";
            var data = await Download(gzUrl, false);

            using var stream = new MemoryStream(data);
            using var reader = new BinaryReader(stream);

            int totalCount = reader.ReadInt32();

            var infos = Enumerable.Range(0, totalCount)
                .Select(_ => new FileInformation(reader))
                .ToArray();

            var downloadCount = 0;
            var queue = new ConcurrentQueue<FileInformation>(infos);
            var tasks = Enumerable.Range(0, taskCount)
                .Select(_ =>
                {
                    return Task.Run(async () =>
                    {
                        while (queue.TryDequeue(out var info))
                        {
                            var outPath = Path.Join(_outDir, info.FileName);
                            var outDir = Path.GetDirectoryName(outPath)!;
                            if (!Directory.Exists(outDir))
                            {
                                Directory.CreateDirectory(outDir);
                            }

                            if (File.Exists(outPath))
                            {
                                var fileInfo = new FileInfo(outPath);
                                if (fileInfo.LastWriteTime == info.Creation
                                    && fileInfo.Length == info.Length)
                                {
                                    Interlocked.Increment(ref downloadCount);
                                    continue;
                                }
                            }

                            try
                            {
                                var url = _host + info.FileName;
                                var dataBuffer = await Download(url, info.Compressed != info.Length)
                                    .ConfigureAwait(false);
                                if (info.Length != dataBuffer.Length)
                                {
                                    throw new Exception("文件错误");
                                }

                                await File.WriteAllBytesAsync(outPath, dataBuffer).ConfigureAwait(false);
                                File.SetLastWriteTime(outPath, info.Creation);

                                Interlocked.Increment(ref downloadCount);
                                Console.WriteLine($"{downloadCount}/{totalCount}: {info.FileName}");
                            }
                            catch (Exception e)
                            {
                                queue.Enqueue(info);
                            }
                        }
                    });
                })
                .ToArray();

            Task.WaitAll(tasks);
        }

        private async ValueTask<byte[]> Download(string url, bool decompress)
        {
            var httpClientHandler = new HttpClientHandler();
            if (_proxy is { } proxy)
            {
                httpClientHandler.Proxy = new WebProxy(proxy);
            }

            using var client = new HttpClient(httpClientHandler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptCharset.Clear();
            client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));

            var task = Task.Run(() => client
                .GetAsync(new Uri(url), HttpCompletionOption.ResponseHeadersRead));

            var response = task.Result;

            using Stream sm = response.Content.ReadAsStream();
            using var ms = new MemoryStream();
            await sm.CopyToAsync(ms);

            byte[] data = ms.ToArray();
            if (decompress)
            {
                return Decompress(data);
            }

            return data;
        }

        private byte[] Decompress(byte[] raw)
        {
            using var gStream = new GZipStream(new MemoryStream(raw), CompressionMode.Decompress);
            const int size = 4096; //4kb
            byte[] buffer = new byte[size];
            using var mStream = new MemoryStream();
            int count;
            do
            {
                count = gStream.Read(buffer, 0, size);
                if (count > 0)
                {
                    mStream.Write(buffer, 0, count);
                }
            } while (count > 0);

            return mStream.ToArray();
        }
    }
}

public class FileInformation
{
    public string FileName; //Relative.
    public int Length, Compressed;
    public DateTime Creation;

    public FileInformation()
    {
    }

    public FileInformation(BinaryReader reader)
    {
        FileName = reader.ReadString();
        Length = reader.ReadInt32();
        Compressed = reader.ReadInt32();

        Creation = DateTime.FromBinary(reader.ReadInt64());
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(FileName);
        writer.Write(Length);
        writer.Write(Compressed);
        writer.Write(Creation.ToBinary());
    }
}