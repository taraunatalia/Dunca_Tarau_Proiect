// <auto-generated />
using System;
using Dunca_Tarau_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dunca_Tarau_Proiect.Migrations
{
    [DbContext(typeof(Dunca_Tarau_ProiectContext))]
    partial class Dunca_Tarau_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Tour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("GroupSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("StartingTourDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.TourCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TourID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TourID");

                    b.ToTable("TourCategory");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Tour", b =>
                {
                    b.HasOne("Dunca_Tarau_Proiect.Models.Country", "Country")
                        .WithMany("Tours")
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.TourCategory", b =>
                {
                    b.HasOne("Dunca_Tarau_Proiect.Models.Category", "Category")
                        .WithMany("TourCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dunca_Tarau_Proiect.Models.Tour", "Tour")
                        .WithMany("TourCategories")
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Category", b =>
                {
                    b.Navigation("TourCategories");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Country", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Dunca_Tarau_Proiect.Models.Tour", b =>
                {
                    b.Navigation("TourCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
