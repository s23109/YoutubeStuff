using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class YtFile
{
    public int YtfileId { get; set; }

    public string? Title { get; set; }

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<RealFile> RealFiles { get; set; } = new List<RealFile>();
}
