﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooDAL;

#nullable disable

namespace ZooDAL.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    partial class ZooDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZooDAL.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"),
                            Age = 2,
                            CategoryID = new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"),
                            Description = "Penguin description",
                            ImagePath = "10b02f99-82cb-45a2-9f6f-9ff5b93aecfa.jpg",
                            Name = "Penguin"
                        },
                        new
                        {
                            Id = new Guid("9a711fee-6d32-4ed0-b1d6-a5f4958d2208"),
                            Age = 5,
                            CategoryID = new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"),
                            Description = "Parrot description",
                            ImagePath = "492db2e8-a2e5-45e1-85a1-58e2f3a206c5.jpg",
                            Name = "Parrot"
                        },
                        new
                        {
                            Id = new Guid("cf058ebc-a989-441a-b89b-5a0de8e95e13"),
                            Age = 3,
                            CategoryID = new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"),
                            Description = "Eagle description",
                            ImagePath = "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg",
                            Name = "Eagle"
                        },
                        new
                        {
                            Id = new Guid("5bd37101-03a7-4862-b330-4663b0da880a"),
                            Age = 8,
                            CategoryID = new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"),
                            Description = "Chimpanzee description",
                            ImagePath = "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg",
                            Name = "Chimpanzee"
                        },
                        new
                        {
                            Id = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Age = 12,
                            CategoryID = new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"),
                            Description = "Gorilla description",
                            ImagePath = "7741d954-515d-4222-a66b-d8f23273ea2c.jpg",
                            Name = "Gorilla"
                        },
                        new
                        {
                            Id = new Guid("8944349c-5d99-4eb1-bd74-5572f99c49fd"),
                            Age = 10,
                            CategoryID = new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"),
                            Description = "Orangutan description",
                            ImagePath = "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg",
                            Name = "Orangutan"
                        },
                        new
                        {
                            Id = new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"),
                            Age = 4,
                            CategoryID = new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"),
                            Description = "Lion description",
                            ImagePath = "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg",
                            Name = "Lion"
                        },
                        new
                        {
                            Id = new Guid("c49c8581-5aee-4085-99e5-99dbc20ff046"),
                            Age = 6,
                            CategoryID = new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"),
                            Description = "Cheetah description",
                            ImagePath = "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg",
                            Name = "Cheetah"
                        },
                        new
                        {
                            Id = new Guid("e080540d-e961-44a3-ac92-304a0832f47a"),
                            Age = 7,
                            CategoryID = new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"),
                            Description = "Tiger description",
                            ImagePath = "d15b6b92-391b-43ea-a55f-31e8f4cd163f.jpg",
                            Name = "Tiger"
                        });
                });

            modelBuilder.Entity("ZooDAL.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"),
                            Name = "Birds"
                        },
                        new
                        {
                            Id = new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"),
                            Name = "Monkeys"
                        },
                        new
                        {
                            Id = new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"),
                            Name = "Cats"
                        });
                });

            modelBuilder.Entity("ZooDAL.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e96e9520-1b38-4c4e-8a31-ed7a3cc42d58"),
                            AnimalID = new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"),
                            Content = "This lion is amazing!"
                        },
                        new
                        {
                            Id = new Guid("28d71b5e-bdff-42ad-b050-c849f4b38dbc"),
                            AnimalID = new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"),
                            Content = "The lion's majestic beauty is breathtaking!"
                        },
                        new
                        {
                            Id = new Guid("70fdc07c-9370-4451-963a-93d3fb378de4"),
                            AnimalID = new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"),
                            Content = "I'm in awe of this incredible lion!"
                        },
                        new
                        {
                            Id = new Guid("91431acc-3f1e-4468-bb07-a05c4428110d"),
                            AnimalID = new Guid("cf058ebc-a989-441a-b89b-5a0de8e95e13"),
                            Content = "The eagle is soaring through the sky with grace!"
                        },
                        new
                        {
                            Id = new Guid("0eb588ee-c116-483b-9175-87f589f8253c"),
                            AnimalID = new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"),
                            Content = "The penguin waddles with cuteness!"
                        },
                        new
                        {
                            Id = new Guid("847a785c-c237-494e-9749-b5506497b9e8"),
                            AnimalID = new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"),
                            Content = "The penguin's sleek feathers are mesmerizing!"
                        },
                        new
                        {
                            Id = new Guid("3899a556-78e1-42a9-be13-4e0e13842fff"),
                            AnimalID = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Content = "The gorilla's strength is awe-inspiring!"
                        },
                        new
                        {
                            Id = new Guid("4647eac2-85b3-45a4-9447-8d3b7671d585"),
                            AnimalID = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Content = "The gorilla's intelligence shines through!"
                        },
                        new
                        {
                            Id = new Guid("d23ad862-00da-4ec9-9219-ae677fed792b"),
                            AnimalID = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Content = "The gorilla's gentle nature is heartwarming!"
                        },
                        new
                        {
                            Id = new Guid("0c4831d4-ec24-476e-bf87-ed957dcb4e4a"),
                            AnimalID = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Content = "The gorilla's interactions with its family are fascinating!"
                        },
                        new
                        {
                            Id = new Guid("53f90afa-3174-40b7-a016-cc574188c191"),
                            AnimalID = new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"),
                            Content = "The gorilla's expressive eyes captivate everyone!"
                        });
                });

            modelBuilder.Entity("ZooDAL.Entities.Animal", b =>
                {
                    b.HasOne("ZooDAL.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ZooDAL.Entities.Comment", b =>
                {
                    b.HasOne("ZooDAL.Entities.Animal", "Animal")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("ZooDAL.Entities.Animal", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
