using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeStuff.Migrations
{
    public partial class UploadBatch_CreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proccessed_File",
                columns: table => new
                {
                    Proccessed_File_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proccessed_File", x => x.Proccessed_File_Id);
                });

            migrationBuilder.CreateTable(
                name: "Upload_Batch",
                columns: table => new
                {
                    upload_batch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_type = table.Column<int>(type: "int", nullable: false),
                    site_type = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upload_Batch", x => x.upload_batch_id);
                });

            migrationBuilder.CreateTable(
                name: "Uploaded_File",
                columns: table => new
                {
                    uploaded_file_id = table.Column<int>(type: "int", nullable: false),
                    upload_batch_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploaded_File", x => x.uploaded_file_id);
                    table.ForeignKey(
                        name: "Uploaded_File_Upload_Batch",
                        column: x => x.upload_batch_id,
                        principalTable: "Upload_Batch",
                        principalColumn: "upload_batch_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "File_Saved",
                columns: table => new
                {
                    file_saved_id = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Uploaded_File_uploaded_file_id = table.Column<int>(type: "int", nullable: true),
                    Proccessed_File_Proccessed_File_Id = table.Column<int>(type: "int", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    file_size = table.Column<long>(type: "bigint", nullable: false),
                    file_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Saved", x => x.file_saved_id);
                    table.ForeignKey(
                        name: "File_Saved_Proccessed_File",
                        column: x => x.Proccessed_File_Proccessed_File_Id,
                        principalTable: "Proccessed_File",
                        principalColumn: "Proccessed_File_Id");
                    table.ForeignKey(
                        name: "File_Saved_Uploaded_File",
                        column: x => x.Uploaded_File_uploaded_file_id,
                        principalTable: "Uploaded_File",
                        principalColumn: "uploaded_file_id");
                });

            migrationBuilder.CreateTable(
                name: "Upload_parts",
                columns: table => new
                {
                    part_id = table.Column<int>(type: "int", nullable: false),
                    uploaded_file_id = table.Column<int>(type: "int", nullable: true),
                    start_time = table.Column<int>(type: "int", nullable: false),
                    end_time = table.Column<int>(type: "int", nullable: false),
                    part_type = table.Column<int>(type: "int", nullable: false),
                    part_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Upload_parts_pk", x => x.part_id);
                    table.ForeignKey(
                        name: "upload_parts_Uploaded_File",
                        column: x => x.uploaded_file_id,
                        principalTable: "Uploaded_File",
                        principalColumn: "uploaded_file_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Parts_Used",
                columns: table => new
                {
                    Proccessed_File_Id = table.Column<int>(type: "int", nullable: false),
                    Part_Order = table.Column<int>(type: "int", nullable: false),
                    Upload_parts_part_id = table.Column<int>(type: "int", nullable: true),
                    Proccessed_File_Proccessed_File_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Parts_Used_pk", x => new { x.Proccessed_File_Id, x.Part_Order });
                    table.ForeignKey(
                        name: "Parts_Used_Proccessed_File_Original_File",
                        column: x => x.Proccessed_File_Id,
                        principalTable: "Proccessed_File",
                        principalColumn: "Proccessed_File_Id");
                    table.ForeignKey(
                        name: "Parts_Used_Proccessed_File_Part",
                        column: x => x.Proccessed_File_Proccessed_File_Id,
                        principalTable: "Proccessed_File",
                        principalColumn: "Proccessed_File_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Parts_Used_Upload_parts",
                        column: x => x.Upload_parts_part_id,
                        principalTable: "Upload_parts",
                        principalColumn: "part_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_Saved_Proccessed_File_Proccessed_File_Id",
                table: "File_Saved",
                column: "Proccessed_File_Proccessed_File_Id");

            migrationBuilder.CreateIndex(
                name: "IX_File_Saved_Uploaded_File_uploaded_file_id",
                table: "File_Saved",
                column: "Uploaded_File_uploaded_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Used_Proccessed_File_Proccessed_File_Id",
                table: "Parts_Used",
                column: "Proccessed_File_Proccessed_File_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_Used_Upload_parts_part_id",
                table: "Parts_Used",
                column: "Upload_parts_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_Upload_parts_uploaded_file_id",
                table: "Upload_parts",
                column: "uploaded_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Uploaded_File_upload_batch_id",
                table: "Uploaded_File",
                column: "upload_batch_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_Saved");

            migrationBuilder.DropTable(
                name: "Parts_Used");

            migrationBuilder.DropTable(
                name: "Proccessed_File");

            migrationBuilder.DropTable(
                name: "Upload_parts");

            migrationBuilder.DropTable(
                name: "Uploaded_File");

            migrationBuilder.DropTable(
                name: "Upload_Batch");
        }
    }
}
