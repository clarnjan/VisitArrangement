﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitArrangement.Infrastructure.Context;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    [DbContext(typeof(VisitArrangementDbContext))]
    [Migration("20241214120135_userTableProblem")]
    partial class userTableProblem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Arrangement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ApprovedByHost")
                        .HasColumnType("bit");

                    b.Property<bool>("ApprovedByVisitor")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostFK")
                        .HasColumnType("int");

                    b.Property<int>("VisitorFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HostFK");

                    b.HasIndex("VisitorFK");

                    b.ToTable("Arrangement", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.LocationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImageFK")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("LocationFK")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationImage", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SentFromFK")
                        .HasColumnType("int");

                    b.Property<int>("SentToFK")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("SentFromFK");

                    b.HasIndex("SentToFK");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArrangementFK")
                        .HasColumnType("int");

                    b.Property<int>("ByUserFK")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ForUserFK")
                        .HasColumnType("int");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyInt");

                    b.HasKey("Id");

                    b.HasIndex("ArrangementFK");

                    b.HasIndex("ByUserFK");

                    b.HasIndex("ForUserFK");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.UserLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationFK")
                        .HasColumnType("int");

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationFK");

                    b.HasIndex("UserFK");

                    b.ToTable("UserLocation", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Arrangement", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.User", "Host")
                        .WithMany()
                        .HasForeignKey("HostFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.User", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.LocationImage", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Message", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.User", "SentFrom")
                        .WithMany()
                        .HasForeignKey("SentFromFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.User", "SentTo")
                        .WithMany()
                        .HasForeignKey("SentToFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SentFrom");

                    b.Navigation("SentTo");
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Review", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.Arrangement", "Arrangement")
                        .WithMany()
                        .HasForeignKey("ArrangementFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.User", "ByUser")
                        .WithMany()
                        .HasForeignKey("ByUserFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.User", "ForUser")
                        .WithMany()
                        .HasForeignKey("ForUserFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Arrangement");

                    b.Navigation("ByUser");

                    b.Navigation("ForUser");
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.UserLocation", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VisitArrangement.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
