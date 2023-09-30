using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeStuff.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Ids_To_Identity_Add_Cover_Photo_Blob_RealFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverPhoto",
                table: "RealFile",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhoto",
                table: "RealFile");
        }
    }
}
