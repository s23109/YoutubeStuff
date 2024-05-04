using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using YoutubeStuff.Models.Music_Module;

namespace YoutubeStuff.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FileSaved> FileSaveds { get; set; } = null!;
        public virtual DbSet<PartsUsed> PartsUseds { get; set; } = null!;
        public virtual DbSet<ProccessedFile> ProccessedFiles { get; set; } = null!;
        public virtual DbSet<UploadBatch> UploadBatches { get; set; } = null!;
        public virtual DbSet<UploadPart> UploadParts { get; set; } = null!;
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileSaved>(entity =>
            {
                entity.ToTable("File_Saved");

                entity.Property(e => e.FileSavedId)
                    .HasMaxLength(32)
                    .HasColumnName("file_saved_id");

                entity.Property(e => e.FileData).HasColumnName("file_data");

                entity.Property(e => e.FileName).HasColumnName("file_name");

                entity.Property(e => e.FileSize).HasColumnName("file_size");

                entity.Property(e => e.FileType).HasColumnName("file_type");

                entity.Property(e => e.ProccessedFileProccessedFileId).HasColumnName("Proccessed_File_Proccessed_File_Id");

                entity.Property(e => e.UploadedFileUploadedFileId).HasColumnName("Uploaded_File_uploaded_file_id");

                entity.HasOne(d => d.ProccessedFileProccessedFile)
                    .WithMany(p => p.FileSaveds)
                    .HasForeignKey(d => d.ProccessedFileProccessedFileId)
                    .HasConstraintName("File_Saved_Proccessed_File");

                entity.HasOne(d => d.UploadedFileUploadedFile)
                    .WithMany(p => p.FileSaveds)
                    .HasForeignKey(d => d.UploadedFileUploadedFileId)
                    .HasConstraintName("File_Saved_Uploaded_File");
            });

            modelBuilder.Entity<PartsUsed>(entity =>
            {
                entity.HasKey(e => new { e.ProccessedFileId, e.PartOrder })
                    .HasName("Parts_Used_pk");

                entity.ToTable("Parts_Used");

                entity.Property(e => e.ProccessedFileId).HasColumnName("Proccessed_File_Id");

                entity.Property(e => e.PartOrder).HasColumnName("Part_Order");

                entity.Property(e => e.ProccessedFileProccessedFileId).HasColumnName("Proccessed_File_Proccessed_File_Id");

                entity.Property(e => e.UploadPartsPartId).HasColumnName("Upload_parts_part_id");

                entity.HasOne(d => d.ProccessedFile)
                    .WithMany(p => p.PartsUsedProccessedFiles)
                    .HasForeignKey(d => d.ProccessedFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Parts_Used_Proccessed_File_Original_File");

                entity.HasOne(d => d.ProccessedFileProccessedFile)
                    .WithMany(p => p.PartsUsedProccessedFileProccessedFiles)
                    .HasForeignKey(d => d.ProccessedFileProccessedFileId)
                    .HasConstraintName("Parts_Used_Proccessed_File_Part");

                entity.HasOne(d => d.UploadPartsPart)
                    .WithMany(p => p.PartsUseds)
                    .HasForeignKey(d => d.UploadPartsPartId)
                    .HasConstraintName("Parts_Used_Upload_parts");
            });

            modelBuilder.Entity<ProccessedFile>(entity =>
            {
                entity.ToTable("Proccessed_File");

                entity.Property(e => e.ProccessedFileId)
                    .ValueGeneratedNever()
                    .HasColumnName("Proccessed_File_Id");
            });

            modelBuilder.Entity<UploadBatch>(entity =>
            {
                entity.ToTable("Upload_Batch");

                entity.Property(e => e.UploadBatchId).HasColumnName("upload_batch_id");

                entity.Property(e => e.SiteType).HasColumnName("site_type");

                entity.Property(e => e.UploadType).HasColumnName("upload_type");
            });

            modelBuilder.Entity<UploadPart>(entity =>
            {
                entity.HasKey(e => e.PartId)
                    .HasName("Upload_parts_pk");

                entity.ToTable("Upload_parts");

                entity.Property(e => e.PartId)
                    .ValueGeneratedNever()
                    .HasColumnName("part_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.PartName).HasColumnName("part_name");

                entity.Property(e => e.PartType).HasColumnName("part_type");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.UploadedFileId).HasColumnName("uploaded_file_id");

                entity.HasOne(d => d.UploadedFile)
                    .WithMany(p => p.UploadParts)
                    .HasForeignKey(d => d.UploadedFileId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("upload_parts_Uploaded_File");
            });

            modelBuilder.Entity<UploadedFile>(entity =>
            {
                entity.ToTable("Uploaded_File");

                entity.Property(e => e.UploadedFileId)
                    .ValueGeneratedNever()
                    .HasColumnName("uploaded_file_id");

                entity.Property(e => e.UploadBatchId).HasColumnName("upload_batch_id");

                entity.HasOne(d => d.UploadBatch)
                    .WithMany(p => p.UploadedFiles)
                    .HasForeignKey(d => d.UploadBatchId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Uploaded_File_Upload_Batch");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
