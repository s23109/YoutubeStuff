namespace YoutubeStuff.Services.Misc.DownloadService
{
    public interface IDownloadService
    {
        long? GetCurrentFileByte();
        long? GetCurrentFileRead();

        long? GetTotaltFileRead();

        long? GetTotalFileAmount();

        public event Action currentFileByteChanged;

        public event Action currentFileReadChanged;

        public event Action totaltFileReadChanged;

        public event Action totalFileAmountChanged;

        bool IsCorrectUrl(string url);

        Task<Tuple<string, int?>> DownloadSingleUrl(string url);

    }



}
