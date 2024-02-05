﻿// <auto-generated />
using System;
using Cards.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cards.Persistence.Migrations
{
    [DbContext(typeof(CardsDbContext))]
    partial class CardsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cards.Domain.Entities.Card", b =>
                {
                    b.Property<Guid>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardId = new Guid("5441c11c-22b5-4b74-9ccb-3834e68a30ec"),
                            Color = "#ff5733",
                            CreatedBy = "7d558b50-4718-453f-bede-4465e9a2dd37",
                            CreatedDate = new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5172),
                            Name = "Clean the house",
                            Status = 0,
                            UserId = new Guid("7d558b50-4718-453f-bede-4465e9a2dd37")
                        },
                        new
                        {
                            CardId = new Guid("1e0d9474-499e-4be5-a295-e6c130f9aa6e"),
                            Color = "#7aff33",
                            CreatedBy = "7d558b50-4718-453f-bede-4465e9a2dd37",
                            CreatedDate = new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5333),
                            Name = "Buy food for the cat",
                            Status = 0,
                            UserId = new Guid("7d558b50-4718-453f-bede-4465e9a2dd37")
                        },
                        new
                        {
                            CardId = new Guid("0faed4dd-dc36-4d16-aa2c-c4bce45f27e6"),
                            Color = "#7aff33",
                            CreatedBy = "3637dd46-f4f2-46cd-bbe4-3a3860d4a215",
                            CreatedDate = new DateTime(2024, 2, 5, 16, 18, 28, 770, DateTimeKind.Local).AddTicks(5357),
                            Name = "Throw garbage",
                            Status = 0,
                            UserId = new Guid("3637dd46-f4f2-46cd-bbe4-3a3860d4a215")
                        });
                });

            modelBuilder.Entity("Cards.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7d558b50-4718-453f-bede-4465e9a2dd37"),
                            Email = "koutlasilias@gmail.com",
                            Password = "rita@4",
                            Role = "Administrator"
                        },
                        new
                        {
                            UserId = new Guid("3637dd46-f4f2-46cd-bbe4-3a3860d4a215"),
                            Email = "pohiosm@gmail.com",
                            Password = "rita@5",
                            Role = "Member"
                        });
                });

            modelBuilder.Entity("Cards.Domain.Entities.Card", b =>
                {
                    b.HasOne("Cards.Domain.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cards.Domain.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
