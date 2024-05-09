using YoutubeStuff.Models.Music_Module;

namespace YoutubeStuff.Models.MusicModule.DTO.Request
{
    public class UploadFilesDto
    {
        //for upload batch
        public UploadType UploadType { get; set; }
        public SiteType? SiteType { get; set; }

        //files data / or links ? 

        //if from user, just files


    }
}
