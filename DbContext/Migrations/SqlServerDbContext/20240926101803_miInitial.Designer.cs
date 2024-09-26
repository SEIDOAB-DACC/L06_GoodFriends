﻿// <auto-generated />
using System;
using DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    [DbContext(typeof(csMainDbContext.SqlServerDbContext))]
    [Migration("20240926101803_miInitial")]
    partial class miInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbModels.csAddressDbM", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("StreetAddress", "ZipCode", "City", "Country")
                        .IsUnique();

                    b.ToTable("Addresses", "supusr");
                });

            modelBuilder.Entity("DbModels.csFriendDbM", b =>
                {
                    b.Property<Guid>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("FriendId");

                    b.HasIndex("AddressId");

                    b.HasIndex("FirstName", "LastName");

                    b.HasIndex("LastName", "FirstName");

                    b.ToTable("Friends", "supusr");
                });

            modelBuilder.Entity("DbModels.csPetDbM", b =>
                {
                    b.Property<Guid>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<int>("Mood")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("PetId");

                    b.HasIndex("FriendId");

                    b.ToTable("Pets", "supusr");
                });

            modelBuilder.Entity("DbModels.csQuoteDbM", b =>
                {
                    b.Property<Guid>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Quote")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Seeded")
                        .HasColumnType("bit");

                    b.HasKey("QuoteId");

                    b.ToTable("Quotes", "supusr");
                });

            modelBuilder.Entity("csFriendDbMcsQuoteDbM", b =>
                {
                    b.Property<Guid>("FriendsDbMFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuotesDbMQuoteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FriendsDbMFriendId", "QuotesDbMQuoteId");

                    b.HasIndex("QuotesDbMQuoteId");

                    b.ToTable("csFriendDbMcsQuoteDbM", "supusr");
                });

            modelBuilder.Entity("DbModels.csFriendDbM", b =>
                {
                    b.HasOne("DbModels.csAddressDbM", "AddressDbM")
                        .WithMany("FriendsDbM")
                        .HasForeignKey("AddressId");

                    b.Navigation("AddressDbM");
                });

            modelBuilder.Entity("DbModels.csPetDbM", b =>
                {
                    b.HasOne("DbModels.csFriendDbM", "FriendDbM")
                        .WithMany("PetsDbM")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendDbM");
                });

            modelBuilder.Entity("csFriendDbMcsQuoteDbM", b =>
                {
                    b.HasOne("DbModels.csFriendDbM", null)
                        .WithMany()
                        .HasForeignKey("FriendsDbMFriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.csQuoteDbM", null)
                        .WithMany()
                        .HasForeignKey("QuotesDbMQuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbModels.csAddressDbM", b =>
                {
                    b.Navigation("FriendsDbM");
                });

            modelBuilder.Entity("DbModels.csFriendDbM", b =>
                {
                    b.Navigation("PetsDbM");
                });
#pragma warning restore 612, 618
        }
    }
}
