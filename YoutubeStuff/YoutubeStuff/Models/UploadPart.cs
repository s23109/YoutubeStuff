using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models
{
    public partial class UploadPart
    {
        public UploadPart()
        {
            PartsUseds = new HashSet<PartsUsed>();
        }

        public int PartId { get; set; }
        public int? UploadedFileId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int PartType { get; set; }
        public string PartName { get; set; } = null!;

        public virtual UploadedFile? UploadedFile { get; set; }
        public virtual ICollection<PartsUsed> PartsUseds { get; set; }
    }
}
