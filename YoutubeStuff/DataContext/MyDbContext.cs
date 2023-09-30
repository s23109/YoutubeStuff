using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YoutubeStuff.Models;

namespace YoutubeStuff.DataContext;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<ArtistTrack> ArtistTracks { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistContain> PlaylistContains { get; set; }

    public virtual DbSet<RealFile> RealFiles { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TrackInFile> TrackInFiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<YtFile> YtFiles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.AtristId).HasName("Artist_pk");

            entity.ToTable("Artist");

            entity.Property(e => e.AtristId).ValueGeneratedNever();
            entity.Property(e => e.ArtistName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ArtistTrack>(entity =>
        {
            entity.HasKey(e => e.ArtistTrackId).HasName("ArtistTrack_pk");

            entity.ToTable("ArtistTrack");

            entity.Property(e => e.ArtistTrackId).ValueGeneratedNever();
            entity.Property(e => e.ArtistAtristId).HasColumnName("Artist_AtristId");
            entity.Property(e => e.TrackTrackId).HasColumnName("Track_TrackId");

            entity.HasOne(d => d.ArtistAtrist).WithMany(p => p.ArtistTracks)
                .HasForeignKey(d => d.ArtistAtristId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArtistTrack_Artist");

            entity.HasOne(d => d.TrackTrack).WithMany(p => p.ArtistTracks)
                .HasForeignKey(d => d.TrackTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArtistTrack_Track");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId).HasName("Playlist_pk");

            entity.ToTable("Playlist");

            entity.Property(e => e.PlaylistId).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PlaylistName)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("YtPlaylist_User");
        });

        modelBuilder.Entity<PlaylistContain>(entity =>
        {
            entity.HasKey(e => e.PlaylistContainsId).HasName("PlaylistContains_pk");

            entity.Property(e => e.PlaylistContainsId).ValueGeneratedNever();
            entity.Property(e => e.PlaylistPlaylistId).HasColumnName("Playlist_PlaylistId");
            entity.Property(e => e.RealFileRealFileId).HasColumnName("RealFile_RealFileId");

            entity.HasOne(d => d.PlaylistPlaylist).WithMany(p => p.PlaylistContains)
                .HasForeignKey(d => d.PlaylistPlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaylistContains_Playlist");

            entity.HasOne(d => d.RealFileRealFile).WithMany(p => p.PlaylistContains)
                .HasForeignKey(d => d.RealFileRealFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaylistContains_RealFile");
        });

        modelBuilder.Entity<RealFile>(entity =>
        {
            entity.HasKey(e => e.RealFileId).HasName("RealFile_pk");

            entity.ToTable("RealFile");

            entity.Property(e => e.RealFileId).ValueGeneratedNever();
            entity.Property(e => e.FileName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.YtFileYtfileId).HasColumnName("YtFile_YTFileId");

            entity.Property(e => e.CoverPhoto).HasColumnType("varbinary(max)");

            entity.HasOne(d => d.YtFileYtfile).WithMany(p => p.RealFiles)
                .HasForeignKey(d => d.YtFileYtfileId)
                .HasConstraintName("RealFile_YtFile");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("Track_pk");

            entity.ToTable("Track");

            entity.Property(e => e.TrackId).ValueGeneratedNever();
            entity.Property(e => e.TrackName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrackInFile>(entity =>
        {
            entity.HasKey(e => e.TrackInFileId).HasName("TrackInFile_pk");

            entity.ToTable("TrackInFile");

            entity.Property(e => e.TrackInFileId).ValueGeneratedNever();
            entity.Property(e => e.RealFileRealFileId).HasColumnName("RealFile_RealFileId");
            entity.Property(e => e.TrackTrackId).HasColumnName("Track_TrackId");

            entity.HasOne(d => d.RealFileRealFile).WithMany(p => p.TrackInFiles)
                .HasForeignKey(d => d.RealFileRealFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TrackInFile_RealFile");

            entity.HasOne(d => d.TrackTrack).WithMany(p => p.TrackInFiles)
                .HasForeignKey(d => d.TrackTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TrackInFile_Track");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pk");

            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<YtFile>(entity =>
        {
            entity.HasKey(e => e.YtfileId).HasName("YtFile_pk");

            entity.ToTable("YtFile");

            entity.Property(e => e.YtfileId)
                .ValueGeneratedNever()
                .HasColumnName("YTFileId");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
