﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoHelp.Data;

#nullable disable

namespace MotoHelp.Migrations
{
    [DbContext(typeof(DBContent))]
    [Migration("20230205163010_add-auth")]
    partial class addauth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MotoHelp.Models.ImageUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdditionalMHDetailId")
                        .HasColumnType("int");

                    b.Property<bool>("IsTitle")
                        .HasColumnType("bit");

                    b.Property<int?>("TitleMHDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalMHDetailId");

                    b.HasIndex("TitleMHDetailId")
                        .IsUnique()
                        .HasFilter("[TitleMHDetailId] IS NOT NULL");

                    b.ToTable("ImageUri");
                });

            modelBuilder.Entity("MotoHelp.Models.MHCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MHCategory");
                });

            modelBuilder.Entity("MotoHelp.Models.MHDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InStock")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MHCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("MHCategoryId");

                    b.ToTable("MHDetail");
                });

            modelBuilder.Entity("MotoHelp.Models.MHService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MHService");
                });

            modelBuilder.Entity("MotoHelp.Models.RequestedCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestedCall");
                });

            modelBuilder.Entity("MotoHelp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MotoHelp.Models.ImageUri", b =>
                {
                    b.HasOne("MotoHelp.Models.MHDetail", "AdditionalMHDetail")
                        .WithMany("AdditionalPictures")
                        .HasForeignKey("AdditionalMHDetailId");

                    b.HasOne("MotoHelp.Models.MHDetail", "TitleMHDetail")
                        .WithOne("TitlePictire")
                        .HasForeignKey("MotoHelp.Models.ImageUri", "TitleMHDetailId");

                    b.Navigation("AdditionalMHDetail");

                    b.Navigation("TitleMHDetail");
                });

            modelBuilder.Entity("MotoHelp.Models.MHDetail", b =>
                {
                    b.HasOne("MotoHelp.Models.MHCategory", "MHCategory")
                        .WithMany("Details")
                        .HasForeignKey("MHCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MHCategory");
                });

            modelBuilder.Entity("MotoHelp.Models.MHCategory", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("MotoHelp.Models.MHDetail", b =>
                {
                    b.Navigation("AdditionalPictures");

                    b.Navigation("TitlePictire");
                });
#pragma warning restore 612, 618
        }
    }
}
