using YoutubeStuff.Services.Misc.DownloadService;
using YoutubeStuff.Services.Misc.FileService;

namespace YoutubeStuff.Services.Misc.YtFileService
{
    public class YtFileService : IYtFileService
    {
        public IFileService _fileService;
        public IDownloadService DownloadService { get; set; }


        public YtFileService(IFileService fileService, IDownloadService downloadService)
        {
            _fileService = fileService;
            this.DownloadService = downloadService;
        }


        public async Task<string> DownloadAndConvertSingle(string url)
        {

            try
            {
                var fileInfo = await DownloadService.DownloadSingleUrl(url);
                var result = await _fileService.ConvertSingularToMp3(fileInfo);
                return result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
