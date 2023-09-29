namespace YoutubeStuff.Services.Misc.FileService
{
    public interface IFileService
    { 
        string TestBinFolder();

        string TestReturnVar();

        Task<string> ConvertSingularToMp3(Tuple<string,int?> fileInfo);
    }
}
