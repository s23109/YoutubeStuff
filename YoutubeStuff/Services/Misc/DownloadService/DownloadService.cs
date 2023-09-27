using System.Text.RegularExpressions;
using VideoLibrary;

namespace YoutubeStuff.Services.Misc.DownloadService
{
    public class DownloadService : IDownloadService
    {
        //11 vid id, 34 list id, pomijając query string
        private readonly Regex regexSingleVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}", RegexOptions.Singleline);
        private readonly Regex regexPlaylistVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}&list=.{34}$", RegexOptions.Singleline);

        //either 
        private readonly Regex regexCorrectUrl = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}(&list=.{34})?$", RegexOptions.Singleline);


        private string _downloadFolder { get; set; }
        private string _binaryfolder { get; set; }

        public DownloadService()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _downloadFolder = config["downloadfolder"];
            _binaryfolder = config["binaryfolder"];
        }

        public bool IsCorrectUrl(string url)
        {
            return regexCorrectUrl.IsMatch(url);
        }


        public async Task<string> DownloadUrl(string url)
        {
            if (!regexSingleVideo.IsMatch(url))
            {
                throw new Exception("Invalid URL given");
            }
            else
            {
                //download ... 
                return await Task.Run(() => {
                    var youtube = YouTube.Default;
                    var video = youtube.GetVideo(url);

                    System.IO.File.WriteAllBytes((_downloadFolder + video.FullName + ".mp4"), video.GetBytes());
                    return video.FullName;

                });
            }
        }

    }
}
