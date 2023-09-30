using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class RealFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RealFileId { get; set; }

    public int? YtFileYtfileId { get; set; }

    public string? FileName { get; set; }

    public byte[]? CoverPhoto { get; set; } 

    public virtual ICollection<PlaylistContain> PlaylistContains { get; set; } = new List<PlaylistContain>();

    public virtual ICollection<TrackInFile> TrackInFiles { get; set; } = new List<TrackInFile>();

    public virtual YtFile? YtFileYtfile { get; set; }
}
