using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeStuff.Migrations
{
    /// <inheritdoc />
    public partial class Init_Post_DB_First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    AtristId = table.Column<int>(type: "int", nullable: false),
                    ArtistName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_pk", x => x.AtristId);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    TrackName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    TrackLengthSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Track_pk", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    PassEnc = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "YtFile",
                columns: table => new
                {
                    YTFileId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("YtFile_pk", x => x.YTFileId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTrack",
                columns: table => new
                {
                    ArtistTrackId = table.Column<int>(type: "int", nullable: false),
                    Artist_AtristId = table.Column<int>(type: "int", nullable: false),
                    Track_TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ArtistTrack_pk", x => x.ArtistTrackId);
                    table.ForeignKey(
                        name: "ArtistTrack_Artist",
                        column: x => x.Artist_AtristId,
                        principalTable: "Artist",
                        principalColumn: "AtristId");
                    table.ForeignKey(
                        name: "ArtistTrack_Track",
                        column: x => x.Track_TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId");
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlaylistName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    PlaylistType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Playlist_pk", x => x.PlaylistId);
                    table.ForeignKey(
                        name: "YtPlaylist_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RealFile",
                columns: table => new
                {
                    RealFileId = table.Column<int>(type: "int", nullable: false),
                    YtFile_YTFileId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RealFile_pk", x => x.RealFileId);
                    table.ForeignKey(
                        name: "RealFile_YtFile",
                        column: x => x.YtFile_YTFileId,
                        principalTable: "YtFile",
                        principalColumn: "YTFileId");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistContains",
                columns: table => new
                {
                    PlaylistContainsId = table.Column<int>(type: "int", nullable: false),
                    Playlist_PlaylistId = table.Column<int>(type: "int", nullable: false),
                    RealFile_RealFileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PlaylistContains_pk", x => x.PlaylistContainsId);
                    table.ForeignKey(
                        name: "PlaylistContains_Playlist",
                        column: x => x.Playlist_PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistId");
                    table.ForeignKey(
                        name: "PlaylistContains_RealFile",
                        column: x => x.RealFile_RealFileId,
                        principalTable: "RealFile",
                        principalColumn: "RealFileId");
                });

            migrationBuilder.CreateTable(
                name: "TrackInFile",
                columns: table => new
                {
                    TrackInFileId = table.Column<int>(type: "int", nullable: false),
                    Track_TrackId = table.Column<int>(type: "int", nullable: false),
                    RealFile_RealFileId = table.Column<int>(type: "int", nullable: false),
                    StartTimeInFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TrackInFile_pk", x => x.TrackInFileId);
                    table.ForeignKey(
                        name: "TrackInFile_RealFile",
                        column: x => x.RealFile_RealFileId,
                        principalTable: "RealFile",
                        principalColumn: "RealFileId");
                    table.ForeignKey(
                        name: "TrackInFile_Track",
                        column: x => x.Track_TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTrack_Artist_AtristId",
                table: "ArtistTrack",
                column: "Artist_AtristId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTrack_Track_TrackId",
                table: "ArtistTrack",
                column: "Track_TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistContains_Playlist_PlaylistId",
                table: "PlaylistContains",
                column: "Playlist_PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistContains_RealFile_RealFileId",
                table: "PlaylistContains",
                column: "RealFile_RealFileId");

            migrationBuilder.CreateIndex(
                name: "IX_RealFile_YtFile_YTFileId",
                table: "RealFile",
                column: "YtFile_YTFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackInFile_RealFile_RealFileId",
                table: "TrackInFile",
                column: "RealFile_RealFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackInFile_Track_TrackId",
                table: "TrackInFile",
                column: "Track_TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistTrack");

            migrationBuilder.DropTable(
                name: "PlaylistContains");

            migrationBuilder.DropTable(
                name: "TrackInFile");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "RealFile");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "YtFile");
        }
    }
}
