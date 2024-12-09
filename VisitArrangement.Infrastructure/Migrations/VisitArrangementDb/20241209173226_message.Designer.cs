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
    [Migration("20241209173226_message")]
    partial class message
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("SentFromId")
                        .HasColumnType("varchar(450)");

                    b.Property<int>("SentToFK")
                        .HasColumnType("int");

                    b.Property<string>("SentToId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("SentFromId");

                    b.HasIndex("SentToId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(450)");

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

                    b.ToTable("User");
                });

            modelBuilder.Entity("VisitArrangement.Domain.Entities.Message", b =>
                {
                    b.HasOne("VisitArrangement.Domain.Entities.User", "SentFrom")
                        .WithMany()
                        .HasForeignKey("SentFromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitArrangement.Domain.Entities.User", "SentTo")
                        .WithMany()
                        .HasForeignKey("SentToId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SentFrom");

                    b.Navigation("SentTo");
                });
#pragma warning restore 612, 618
        }
    }
}
