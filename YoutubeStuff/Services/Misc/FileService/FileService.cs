using System.Diagnostics;

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
            
            Process process = new Process() { StartInfo = psi};
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

        public async Task<string> ConvertSingularToMp3(string fileName)
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName= fileName,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = _downloadFolder
            };

            //first check if file exists
            if (!File.Exists(_downloadFolder+"\\"+fileName)) {
                throw new Exception("File does not exist");
            }
            else
            {
                return await Task.Run(() => {
                    return "asd";
                
                });
            }

        }
    }
}
