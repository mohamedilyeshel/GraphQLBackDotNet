﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.DataAccess;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    partial class ToDoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Entities.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "lezimni ntayah el sabouna",
                            IsDone = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "bech nrakah el live chat",
                            IsDone = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "nwali rajel",
                            IsDone = false,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "niklek omk",
                            IsDone = true,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("ToDoList.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthdayDate = new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1585),
                            Email = "hamdi@gmail.com",
                            FirstName = "Hamdi",
                            LastName = "Bali"
                        },
                        new
                        {
                            Id = 2,
                            BirthdayDate = new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1598),
                            Email = "mahdi@gmail.com",
                            FirstName = "Mahdi",
                            LastName = "Bougriba"
                        },
                        new
                        {
                            Id = 3,
                            BirthdayDate = new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1600),
                            Email = "ilyes@gmail.com",
                            FirstName = "Ilyes",
                            LastName = "Helal"
                        },
                        new
                        {
                            Id = 4,
                            BirthdayDate = new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1602),
                            Email = "rayen@gmail.com",
                            FirstName = "Rayen",
                            LastName = "Zebi"
                        });
                });

            modelBuilder.Entity("ToDoList.Entities.Models.ToDo", b =>
                {
                    b.HasOne("ToDoList.Entities.Models.User", "User")
                        .WithMany("ToDos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDoList.Entities.Models.User", b =>
                {
                    b.Navigation("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
