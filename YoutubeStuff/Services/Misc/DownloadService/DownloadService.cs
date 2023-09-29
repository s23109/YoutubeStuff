using System.Text.RegularExpressions;
using VideoLibrary;

namespace YoutubeStuff.Services.Misc.DownloadService
{
    public class DownloadService : IDownloadService
    {
        //11 vid id, 34 list id, pomijając query string, Polubiane filmy - LL 
        private readonly Regex regexSingleVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}", RegexOptions.Singleline);
        private readonly Regex regexPlaylistVideo = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}&list=.{34}$", RegexOptions.Singleline);

        //either 
        private readonly Regex regexCorrectUrl = new("^https:\\/\\/www\\.youtube\\.com\\/watch\\?v\\=.{11}(&list=.{34})?$", RegexOptions.Singleline);


        private string _downloadFolder { get; set; }
        private string _binaryfolder { get; set; }
        public long? currentFileByte { get; set; } = 0L;
        public long? currentFileRead { get; set; } = 0L;
        public long? totaltFileRead { get; set; } = 0L;
        public long? totalFileAmount { get; set; } = 0L;

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


        public Task<Tuple<string, int?>> DownloadSingleUrl(string url)
        {
            if (!regexSingleVideo.IsMatch(url))
            {
                throw new Exception("Invalid URL given");
            }
            else
            {
                //download ... 
                return Task.Run(async () => {
                    var youtube = YouTube.Default;
                    var video = youtube.GetVideo(url);
                    var client = new HttpClient();
                    
                    currentFileRead = 0;

                    using (Stream output = File.OpenWrite((_downloadFolder + video.FullName)))
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Head, video.Uri))
                        {
                            currentFileByte = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result.Content.Headers.ContentLength;
                        }

                        using (var input = await client.GetStreamAsync(video.Uri))
                        {
                            byte[] buffer = new byte[16 * 1024];
                            int read;
                            //download start

                            while ((read = input.Read(buffer,0,buffer.Length))> 0)
                            {
                                output.Write(buffer, 0, read);
                                currentFileRead += read;
                            }

                        }


                    }


                    System.IO.File.WriteAllBytes((_downloadFolder + video.FullName), video.GetBytes());
                    return new Tuple<string,int?>(video.FullName,video.Info.LengthSeconds);

                });
            }
        }
    }
}
