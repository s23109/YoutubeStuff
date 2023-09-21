using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public string PlaylistName { get; set; } = null!;

    public int PlaylistType { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public virtual ICollection<PlaylistContain> PlaylistContains { get; set; } = new List<PlaylistContain>();

    public virtual User User { get; set; } = null!;
}
