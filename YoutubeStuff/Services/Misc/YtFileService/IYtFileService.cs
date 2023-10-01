
using YoutubeStuff.Services.Misc.DownloadService;

namespace YoutubeStuff.Services.Misc.YtFileService
{
    public interface IYtFileService
    {
        public IDownloadService DownloadService { get; set; }
        Task<string> DownloadAndConvertSingle(string url);

    }
}
