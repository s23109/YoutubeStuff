using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public byte[] PassEnc { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
