using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models.Music_Module
{
    public partial class FileSaved
    {
        public string FileSavedId { get; set; } = null!;
        public int? UploadedFileUploadedFileId { get; set; }
        public int? ProccessedFileProccessedFileId { get; set; }
        public string FileName { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;
        public long FileSize { get; set; }
        public int FileType { get; set; }

        public virtual ProccessedFile? ProccessedFileProccessedFile { get; set; }
        public virtual UploadedFile? UploadedFileUploadedFile { get; set; }
    }
}
