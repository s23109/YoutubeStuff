using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class ArtistTrack
{
    public int ArtistTrackId { get; set; }

    public int ArtistAtristId { get; set; }

    public int TrackTrackId { get; set; }

    public virtual Artist ArtistAtrist { get; set; } = null!;

    public virtual Track TrackTrack { get; set; } = null!;
}
