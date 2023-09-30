using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class ArtistTrack
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ArtistTrackId { get; set; }

    public int ArtistAtristId { get; set; }

    public int TrackTrackId { get; set; }

    public virtual Artist ArtistAtrist { get; set; } = null!;

    public virtual Track TrackTrack { get; set; } = null!;
}
