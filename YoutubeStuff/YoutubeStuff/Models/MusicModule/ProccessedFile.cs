using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models.Music_Module
{
    public partial class ProccessedFile
    {
        public ProccessedFile()
        {
            FileSaveds = new HashSet<FileSaved>();
            PartsUsedProccessedFileProccessedFiles = new HashSet<PartsUsed>();
            PartsUsedProccessedFiles = new HashSet<PartsUsed>();
        }

        public int ProccessedFileId { get; set; }

        public virtual ICollection<FileSaved> FileSaveds { get; set; }
        public virtual ICollection<PartsUsed> PartsUsedProccessedFileProccessedFiles { get; set; }
        public virtual ICollection<PartsUsed> PartsUsedProccessedFiles { get; set; }
    }
}
