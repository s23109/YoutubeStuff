using System.Diagnostics;
using System.Text;

namespace YoutubeStuff.Services.Misc.FileService
{
    public class FileService : IFileService
    {

        private string _downloadFolder { get; set; }
        private string _binaryfolder { get; set; }

        public FileService()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            _downloadFolder = config["downloadfolder"];
            _binaryfolder = config["binaryfolder"];
        }



        public string TestReturnVar()
        {
            return _downloadFolder + "\n" + _binaryfolder;
        }

        public string TestBinFolder()
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = _binaryfolder
            };

            Process process = new Process() { StartInfo = psi };
            process.Start();

            StreamWriter sw = process.StandardInput;
            StreamReader sr = process.StandardOutput;

            sw.WriteLine("dir");

            sw.Close();

            string output = sr.ReadToEnd();

            process.WaitForExit();

            sr.Close();
            process.Close();

            return output;

        }

        public async Task<string> ConvertSingularToMp3(Tuple<string, int?> fileInfo)
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = _downloadFolder
            };

            //first check if file exists
            if (!File.Exists(_downloadFolder + fileInfo.Item1))
            {
                throw new Exception("File does not exist");
            }
            else
            {



                return await Task.Run(() =>
                {
                    Process process = new Process() { StartInfo = psi };
                    process.Start();

                    string newName = (fileInfo.Item1).Remove(fileInfo.Item1.Length - 1) + "3";
                    string tempAlbumCoverName = "cover.png";


                    StreamWriter sw = process.StandardInput;
                    StreamReader sr = process.StandardOutput;

                    //first extract cover photo

                    sw.WriteLine($"ffmpeg -i \"{fileInfo.Item1}\" -ss {GetHalfTimeString(fileInfo.Item2)} -vframes 1 -vf \"scale=trunc(iw/2)*2:trunc(ih/2)*2\" {tempAlbumCoverName}");

                    //then given the cover photo extract audio 
                    sw.WriteLine($"ffmpeg -i \"{fileInfo.Item1}\" -i \"{tempAlbumCoverName}\" -map 0:a -map 1 -c:a libmp3lame -b:a 192k -id3v2_version 3 -metadata:s:v title=\"Album Cover\" -metadata:s:v comment=\"Cover (front)\" {newName}");

                    sw.Close();

                    string output = sr.ReadToEnd();

                    process.WaitForExit();

                    sr.Close();
                    process.Close();



                    return newName;
                });
            }

        }


        static string GetHalfTimeString(int? length)
        {
            if (length.HasValue)
            {
                TimeSpan timespan = TimeSpan.FromSeconds(length.Value / 2);
                return timespan.ToString(@"hh\:mm\:ss");
            }
            else
            {
                return "00:00:00";
            }
        }


        static string MakeStringCmdSafe(string input)
        {
            StringBuilder safeString = new StringBuilder();
            List<char> charsToEscape = new List<char> { ' ','&', '(', ')', '[', ']', '{', '}', '^', ';', '!', '"', '<', '>', '|', '`' };



            foreach (char c in input)
            {
                if (charsToEscape.Contains(c))
                {
                    safeString.Append('\\');
                    safeString.Append(c);
                }
                else
                {
                    safeString.Append(c);
                }
            }

            return safeString.ToString();
        }

    }
}
