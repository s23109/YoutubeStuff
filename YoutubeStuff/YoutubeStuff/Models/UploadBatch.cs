using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models
{
    public partial class UploadBatch
    {
        public UploadBatch()
        {
            UploadedFiles = new HashSet<UploadedFile>();
        }

        public int UploadBatchId { get; set; }
        public int UploadType { get; set; }
        public int? SiteType { get; set; }

        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
    }
}
