using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class TrackInFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TrackInFileId { get; set; }

    public int TrackTrackId { get; set; }

    public int RealFileRealFileId { get; set; }

    public int StartTimeInFile { get; set; }

    public virtual RealFile RealFileRealFile { get; set; } = null!;

    public virtual Track TrackTrack { get; set; } = null!;
}
