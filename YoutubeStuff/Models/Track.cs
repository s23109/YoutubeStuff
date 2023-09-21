using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string TrackName { get; set; } = null!;

    public int TrackLengthSec { get; set; }

    public virtual ICollection<ArtistTrack> ArtistTracks { get; set; } = new List<ArtistTrack>();

    public virtual ICollection<TrackInFile> TrackInFiles { get; set; } = new List<TrackInFile>();
}
