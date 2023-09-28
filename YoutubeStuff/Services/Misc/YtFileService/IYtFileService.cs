
namespace YoutubeStuff.Services.Misc.YtFileService
{
    public interface IYtFileService
    {
        Task<string> DownloadAndConvertSingle(string url);

    }
}
