using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class Playlist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public string PlaylistName { get; set; } = null!;

    public PlaylistType PlaylistType { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public virtual ICollection<PlaylistContain> PlaylistContains { get; set; } = new List<PlaylistContain>();

    public virtual User User { get; set; } = null!;
}

public enum PlaylistType
{
    Youtube, Custom
}
