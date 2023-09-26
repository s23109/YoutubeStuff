using System.Text.RegularExpressions;
using YoutubeStuff.Utils;

namespace YoutubeStuff.Services.Misc.DownloadService
{
    public class DownloadService : IDownloadService
    {
        //11 vid id, 34 list id, pomijając query string
        private readonly Regex regexSingleVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}", RegexOptions.Singleline);
        private readonly Regex regexPlaylistVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}&list=.{34}$", RegexOptions.Singleline);

        //either 
        private readonly Regex regexCorrectUrl = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}(&list=.{34})?$", RegexOptions.Singleline);


        public bool IsCorrectUrl(string url)
        {
            return regexCorrectUrl.IsMatch(url);
        }
    }
}
