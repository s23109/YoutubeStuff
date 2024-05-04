namespace YoutubeStuff.Services.MusicModule.DownloadUploadService
{
    public class DownloadUploadService : IDownloadUploadService
    {


        private static string _downloadFolder { get; set; }
        


        public DownloadUploadService()
        {
            //set server upload folder (pre db bufferred)
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            _downloadFolder = config["DownloadFolder"];

        }

    }
}
