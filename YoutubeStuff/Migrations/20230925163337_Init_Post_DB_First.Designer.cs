﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeStuff.DataContext;

#nullable disable

namespace YoutubeStuff.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230925163337_Init_Post_DB_First")]
    partial class Init_Post_DB_First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YoutubeStuff.Models.Artist", b =>
                {
                    b.Property<int>("AtristId")
                        .HasColumnType("int");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("AtristId")
                        .HasName("Artist_pk");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.ArtistTrack", b =>
                {
                    b.Property<int>("ArtistTrackId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistAtristId")
                        .HasColumnType("int")
                        .HasColumnName("Artist_AtristId");

                    b.Property<int>("TrackTrackId")
                        .HasColumnType("int")
                        .HasColumnName("Track_TrackId");

                    b.HasKey("ArtistTrackId")
                        .HasName("ArtistTrack_pk");

                    b.HasIndex("ArtistAtristId");

                    b.HasIndex("TrackTrackId");

                    b.ToTable("ArtistTrack", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("PlaylistType")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId")
                        .HasName("Playlist_pk");

                    b.HasIndex("UserId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.PlaylistContain", b =>
                {
                    b.Property<int>("PlaylistContainsId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistPlaylistId")
                        .HasColumnType("int")
                        .HasColumnName("Playlist_PlaylistId");

                    b.Property<int>("RealFileRealFileId")
                        .HasColumnType("int")
                        .HasColumnName("RealFile_RealFileId");

                    b.HasKey("PlaylistContainsId")
                        .HasName("PlaylistContains_pk");

                    b.HasIndex("PlaylistPlaylistId");

                    b.HasIndex("RealFileRealFileId");

                    b.ToTable("PlaylistContains");
                });

            modelBuilder.Entity("YoutubeStuff.Models.RealFile", b =>
                {
                    b.Property<int>("RealFileId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("YtFileYtfileId")
                        .HasColumnType("int")
                        .HasColumnName("YtFile_YTFileId");

                    b.HasKey("RealFileId")
                        .HasName("RealFile_pk");

                    b.HasIndex("YtFileYtfileId");

                    b.ToTable("RealFile", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("TrackLengthSec")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("TrackId")
                        .HasName("Track_pk");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.TrackInFile", b =>
                {
                    b.Property<int>("TrackInFileId")
                        .HasColumnType("int");

                    b.Property<int>("RealFileRealFileId")
                        .HasColumnType("int")
                        .HasColumnName("RealFile_RealFileId");

                    b.Property<int>("StartTimeInFile")
                        .HasColumnType("int");

                    b.Property<int>("TrackTrackId")
                        .HasColumnType("int")
                        .HasColumnName("Track_TrackId");

                    b.HasKey("TrackInFileId")
                        .HasName("TrackInFile_pk");

                    b.HasIndex("RealFileRealFileId");

                    b.HasIndex("TrackTrackId");

                    b.ToTable("TrackInFile", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PassEnc")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("UserId")
                        .HasName("User_pk");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.YtFile", b =>
                {
                    b.Property<int>("YtfileId")
                        .HasColumnType("int")
                        .HasColumnName("YTFileId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("URL");

                    b.HasKey("YtfileId")
                        .HasName("YtFile_pk");

                    b.ToTable("YtFile", (string)null);
                });

            modelBuilder.Entity("YoutubeStuff.Models.ArtistTrack", b =>
                {
                    b.HasOne("YoutubeStuff.Models.Artist", "ArtistAtrist")
                        .WithMany("ArtistTracks")
                        .HasForeignKey("ArtistAtristId")
                        .IsRequired()
                        .HasConstraintName("ArtistTrack_Artist");

                    b.HasOne("YoutubeStuff.Models.Track", "TrackTrack")
                        .WithMany("ArtistTracks")
                        .HasForeignKey("TrackTrackId")
                        .IsRequired()
                        .HasConstraintName("ArtistTrack_Track");

                    b.Navigation("ArtistAtrist");

                    b.Navigation("TrackTrack");
                });

            modelBuilder.Entity("YoutubeStuff.Models.Playlist", b =>
                {
                    b.HasOne("YoutubeStuff.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("YtPlaylist_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YoutubeStuff.Models.PlaylistContain", b =>
                {
                    b.HasOne("YoutubeStuff.Models.Playlist", "PlaylistPlaylist")
                        .WithMany("PlaylistContains")
                        .HasForeignKey("PlaylistPlaylistId")
                        .IsRequired()
                        .HasConstraintName("PlaylistContains_Playlist");

                    b.HasOne("YoutubeStuff.Models.RealFile", "RealFileRealFile")
                        .WithMany("PlaylistContains")
                        .HasForeignKey("RealFileRealFileId")
                        .IsRequired()
                        .HasConstraintName("PlaylistContains_RealFile");

                    b.Navigation("PlaylistPlaylist");

                    b.Navigation("RealFileRealFile");
                });

            modelBuilder.Entity("YoutubeStuff.Models.RealFile", b =>
                {
                    b.HasOne("YoutubeStuff.Models.YtFile", "YtFileYtfile")
                        .WithMany("RealFiles")
                        .HasForeignKey("YtFileYtfileId")
                        .HasConstraintName("RealFile_YtFile");

                    b.Navigation("YtFileYtfile");
                });

            modelBuilder.Entity("YoutubeStuff.Models.TrackInFile", b =>
                {
                    b.HasOne("YoutubeStuff.Models.RealFile", "RealFileRealFile")
                        .WithMany("TrackInFiles")
                        .HasForeignKey("RealFileRealFileId")
                        .IsRequired()
                        .HasConstraintName("TrackInFile_RealFile");

                    b.HasOne("YoutubeStuff.Models.Track", "TrackTrack")
                        .WithMany("TrackInFiles")
                        .HasForeignKey("TrackTrackId")
                        .IsRequired()
                        .HasConstraintName("TrackInFile_Track");

                    b.Navigation("RealFileRealFile");

                    b.Navigation("TrackTrack");
                });

            modelBuilder.Entity("YoutubeStuff.Models.Artist", b =>
                {
                    b.Navigation("ArtistTracks");
                });

            modelBuilder.Entity("YoutubeStuff.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistContains");
                });

            modelBuilder.Entity("YoutubeStuff.Models.RealFile", b =>
                {
                    b.Navigation("PlaylistContains");

                    b.Navigation("TrackInFiles");
                });

            modelBuilder.Entity("YoutubeStuff.Models.Track", b =>
                {
                    b.Navigation("ArtistTracks");

                    b.Navigation("TrackInFiles");
                });

            modelBuilder.Entity("YoutubeStuff.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("YoutubeStuff.Models.YtFile", b =>
                {
                    b.Navigation("RealFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
