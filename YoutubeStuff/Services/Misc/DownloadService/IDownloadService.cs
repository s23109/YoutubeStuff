using YoutubeStuff.Utils;

namespace YoutubeStuff.Services.Misc.DownloadService
{
    public interface IDownloadService
    {
        bool IsCorrectUrl(string url);

        Task<string> DownloadSingleUrl(string url);

    }



}
