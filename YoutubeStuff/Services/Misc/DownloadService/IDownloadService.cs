using YoutubeStuff.Utils;

namespace YoutubeStuff.Services.Misc.DownloadService
{
    public interface IDownloadService
    {
        long? currentFileByte { get; set; }
        long? currentFileRead { get; set; }

        long? totaltFileRead { get; set; }

        long? totalFileAmount { get; set; }

        bool IsCorrectUrl(string url);

        Task<Tuple<string, int?>> DownloadSingleUrl(string url);

    }



}
