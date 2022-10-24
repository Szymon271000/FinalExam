﻿// <auto-generated />
using System;
using CrimeScene.Datas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrimeScene.Migrations
{
    [DbContext(typeof(LawEnforcementContext))]
    partial class LawEnforcementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CrimeScene.Datas.Models.CrimeEvent", b =>
                {
                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LawEnforcementId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventId");

                    b.HasIndex("LawEnforcementId");

                    b.ToTable("crimeEvents");
                });

            modelBuilder.Entity("CrimeScene.Datas.Models.LawEnforcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("RankEnforcementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RankEnforcementId");

                    b.ToTable("lawEnforcements");
                });

            modelBuilder.Entity("CrimeScene.Datas.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ranks");
                });

            modelBuilder.Entity("CrimeScene.Datas.Models.CrimeEvent", b =>
                {
                    b.HasOne("CrimeScene.Datas.Models.LawEnforcement", null)
                        .WithMany("Events")
                        .HasForeignKey("LawEnforcementId");
                });

            modelBuilder.Entity("CrimeScene.Datas.Models.LawEnforcement", b =>
                {
                    b.HasOne("CrimeScene.Datas.Models.Rank", "RankEnforcement")
                        .WithMany()
                        .HasForeignKey("RankEnforcementId");

                    b.Navigation("RankEnforcement");
                });

            modelBuilder.Entity("CrimeScene.Datas.Models.LawEnforcement", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
