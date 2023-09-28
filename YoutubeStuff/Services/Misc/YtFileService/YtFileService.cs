using YoutubeStuff.Services.Misc.DownloadService;
using YoutubeStuff.Services.Misc.FileService;

namespace YoutubeStuff.Services.Misc.YtFileService
{
    public class YtFileService : IYtFileService
    {
        private IFileService _fileService;
        private IDownloadService _downloadService;

        public YtFileService(IFileService fileService, IDownloadService downloadService)
        {
            _fileService = fileService;
            _downloadService = downloadService;
        }

        public async Task<string> DownloadAndConvertSingle(string url)
        {

            try
            {
                var filename = await _downloadService.DownloadSingleUrl(url);
                Task.Delay(1000).Wait();
                await _fileService.ConvertSingularToMp3(filename);
                return filename;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
