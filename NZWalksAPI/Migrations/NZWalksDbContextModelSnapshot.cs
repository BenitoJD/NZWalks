﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalksAPI.Data;

#nullable disable

namespace NZWalksAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    partial class NZWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d0c401a-2692-4319-af88-f5dc8cc1882f"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("2966e4be-e9c2-40aa-a138-682e5c1cdbf9"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("2e708c42-678e-4fb9-a389-3708c550aecd"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28a75517-4b97-49c8-a2fe-fdeeb21618b9"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "images.pixel.com/photos/auckland"
                        },
                        new
                        {
                            Id = new Guid("17599607-1c37-4343-b015-dbdf67572807"),
                            Code = "WLG",
                            Name = "Wellington",
                            RegionImageUrl = "images.pixel.com/photos/wellington"
                        },
                        new
                        {
                            Id = new Guid("54be8188-ecde-47ff-9908-1f78fc122aeb"),
                            Code = "CHC",
                            Name = "Christchurch",
                            RegionImageUrl = "images.pixel.com/photos/christchurch"
                        },
                        new
                        {
                            Id = new Guid("88bf3d86-3721-4c85-a360-2ee1720cf87d"),
                            Code = "HAM",
                            Name = "Hamilton",
                            RegionImageUrl = "images.pixel.com/photos/hamilton"
                        },
                        new
                        {
                            Id = new Guid("e8dbdc31-e3fb-4436-b78d-ab8993334aba"),
                            Code = "TRG",
                            Name = "Tauranga",
                            RegionImageUrl = "images.pixel.com/photos/tauranga"
                        },
                        new
                        {
                            Id = new Guid("58632891-1d35-465c-8053-379e3d6566bd"),
                            Code = "DUD",
                            Name = "Dunedin",
                            RegionImageUrl = "images.pixel.com/photos/dunedin"
                        },
                        new
                        {
                            Id = new Guid("d43748c1-c040-49f2-a856-2e8f5e80ae3f"),
                            Code = "NPE",
                            Name = "Napier",
                            RegionImageUrl = "images.pixel.com/photos/napier"
                        },
                        new
                        {
                            Id = new Guid("a6dacde2-9ff7-44b7-8d7d-7881cb2150a5"),
                            Code = "ROT",
                            Name = "Rotorua",
                            RegionImageUrl = "images.pixel.com/photos/rotorua"
                        },
                        new
                        {
                            Id = new Guid("ee8bb125-6df3-487f-bbd6-6f7a590ce815"),
                            Code = "ZQN",
                            Name = "Queenstown",
                            RegionImageUrl = "images.pixel.com/photos/queenstown"
                        },
                        new
                        {
                            Id = new Guid("e1ff24cc-b9e9-4a13-9f9c-8254e125468c"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "images.pixel.com/photos/nelson"
                        },
                        new
                        {
                            Id = new Guid("f2cb14e5-33fb-4c97-9c5c-2f347d65eead"),
                            Code = "PMR",
                            Name = "Palmerston North",
                            RegionImageUrl = "images.pixel.com/photos/palmerston-north"
                        },
                        new
                        {
                            Id = new Guid("1078793b-7c4c-4b8b-9529-510205577b52"),
                            Code = "NPL",
                            Name = "New Plymouth",
                            RegionImageUrl = "images.pixel.com/photos/new-plymouth"
                        },
                        new
                        {
                            Id = new Guid("7d30d8eb-b783-4a78-94e5-df49179c5273"),
                            Code = "WRE",
                            Name = "Whangarei",
                            RegionImageUrl = "images.pixel.com/photos/whangarei"
                        },
                        new
                        {
                            Id = new Guid("0f39db6b-065c-4cd2-b177-ad3152708314"),
                            Code = "IVC",
                            Name = "Invercargill",
                            RegionImageUrl = "images.pixel.com/photos/invercargill"
                        },
                        new
                        {
                            Id = new Guid("13668196-071a-4ab2-8cc1-c2c2914d3b3a"),
                            Code = "GIS",
                            Name = "Gisborne",
                            RegionImageUrl = "images.pixel.com/photos/gisborne"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("WalkImageUrl")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
