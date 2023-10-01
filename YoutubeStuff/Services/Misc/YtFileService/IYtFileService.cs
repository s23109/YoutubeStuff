
using YoutubeStuff.Services.Misc.DownloadService;

namespace YoutubeStuff.Services.Misc.YtFileService
{
    public interface IYtFileService
    {
        public IDownloadService _downloadService { get; set; }
        Task<string> DownloadAndConvertSingle(string url);

    }
}
