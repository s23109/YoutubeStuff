using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class Artist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AtristId { get; set; }

    public string ArtistName { get; set; } = null!;

    public virtual ICollection<ArtistTrack> ArtistTracks { get; set; } = new List<ArtistTrack>();
}
