using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models
{
    public partial class UploadedFile
    {
        public UploadedFile()
        {
            FileSaveds = new HashSet<FileSaved>();
            UploadParts = new HashSet<UploadPart>();
        }

        public int UploadedFileId { get; set; }
        public int? UploadBatchId { get; set; }

        public virtual UploadBatch? UploadBatch { get; set; }
        public virtual ICollection<FileSaved> FileSaveds { get; set; }
        public virtual ICollection<UploadPart> UploadParts { get; set; }
    }
}
