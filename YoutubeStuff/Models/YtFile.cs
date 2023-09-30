using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeStuff.Models;

public partial class YtFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int YtfileId { get; set; }

    public string? Title { get; set; }

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<RealFile> RealFiles { get; set; } = new List<RealFile>();
}
