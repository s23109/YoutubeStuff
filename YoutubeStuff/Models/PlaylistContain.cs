using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class PlaylistContain
{
    public int PlaylistContainsId { get; set; }

    public int PlaylistPlaylistId { get; set; }

    public int RealFileRealFileId { get; set; }

    public virtual Playlist PlaylistPlaylist { get; set; } = null!;

    public virtual RealFile RealFileRealFile { get; set; } = null!;
}
