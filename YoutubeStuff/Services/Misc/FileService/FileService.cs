using Microsoft.IdentityModel.Tokens;

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

        public bool TestBinFolder()
        {
            throw new NotImplementedException();
        }
    }
}
