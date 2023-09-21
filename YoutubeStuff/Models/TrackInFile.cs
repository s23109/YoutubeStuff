using System;
using System.Collections.Generic;

namespace YoutubeStuff.Models;

public partial class TrackInFile
{
    public int TrackInFileId { get; set; }

    public int TrackTrackId { get; set; }

    public int RealFileRealFileId { get; set; }

    public int StartTimeInFile { get; set; }

    public virtual RealFile RealFileRealFile { get; set; } = null!;

    public virtual Track TrackTrack { get; set; } = null!;
}
