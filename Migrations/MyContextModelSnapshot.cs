﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScraper_PropertyResearch.Models;

#nullable disable

namespace WebScraper_PropertyResearch.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.SiteCheck", b =>
                {
                    b.Property<int>("SiteCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SiteCheckName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SiteCheckParcelID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SiteCheckId");

                    b.HasIndex("UserId");

                    b.ToTable("SiteChecks");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.UsedSiteCheck", b =>
                {
                    b.Property<int>("UsedSiteCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SiteCheckId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UsedSiteCheckId");

                    b.HasIndex("SiteCheckId");

                    b.HasIndex("UserId");

                    b.ToTable("UsedSiteChecks");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.SiteCheck", b =>
                {
                    b.HasOne("WebScraper_PropertyResearch.Models.User", "Creator")
                        .WithMany("CreatedSiteChecks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.UsedSiteCheck", b =>
                {
                    b.HasOne("WebScraper_PropertyResearch.Models.SiteCheck", "SiteCheck")
                        .WithMany("StaffCreatedSiteChecks")
                        .HasForeignKey("SiteCheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebScraper_PropertyResearch.Models.User", "User")
                        .WithMany("UsedSiteChecks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiteCheck");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.SiteCheck", b =>
                {
                    b.Navigation("StaffCreatedSiteChecks");
                });

            modelBuilder.Entity("WebScraper_PropertyResearch.Models.User", b =>
                {
                    b.Navigation("CreatedSiteChecks");

                    b.Navigation("UsedSiteChecks");
                });
#pragma warning restore 612, 618
        }
    }
}
