using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class Artist
{
    public int AtristId { get; set; }

    public string ArtistName { get; set; } = null!;

    public virtual ICollection<ArtistTrack> ArtistTracks { get; set; } = new List<ArtistTrack>();
}
