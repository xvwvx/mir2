// See https://aka.ms/new-console-template for more information


using AssetDownload;
var host = "http://mirfiles.com/resources/mir2/crystal/patch/";
var outDir = @"D:\Game\Mir2\mir2\Build\Client\Debug\";
var proxy = "http://127.0.0.1:7890";

var download = new ResDownload(outDir, host, proxy);
download.DownloadAll();