using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models.Music_Module
{
    public partial class PartsUsed
    {
        public int ProccessedFileId { get; set; }
        public int PartOrder { get; set; }
        public int? UploadPartsPartId { get; set; }
        public int? ProccessedFileProccessedFileId { get; set; }

        public virtual ProccessedFile ProccessedFile { get; set; } = null!;
        public virtual ProccessedFile? ProccessedFileProccessedFile { get; set; }
        public virtual UploadPart? UploadPartsPart { get; set; }
    }
}
