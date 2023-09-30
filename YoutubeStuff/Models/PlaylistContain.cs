using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class PlaylistContain
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlaylistContainsId { get; set; }

    public int PlaylistPlaylistId { get; set; }

    public int RealFileRealFileId { get; set; }

    public virtual Playlist PlaylistPlaylist { get; set; } = null!;

    public virtual RealFile RealFileRealFile { get; set; } = null!;
}
