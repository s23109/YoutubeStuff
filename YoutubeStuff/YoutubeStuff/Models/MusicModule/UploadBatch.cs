using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models.Music_Module
{
    public partial class UploadBatch
    {
        public UploadBatch()
        {
            UploadedFiles = new HashSet<UploadedFile>();
        }

        public int UploadBatchId { get; set; }
        public UploadType UploadType { get; set; }
        public SiteType? SiteType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
    }

    public enum UploadType
    {
        All = 0, //for filtering
        UserFiles = 1,
        FromSite = 2,
    }

    public enum SiteType
    {
        All = 0, // for filtering
        Youtube = 1,
    }
}
