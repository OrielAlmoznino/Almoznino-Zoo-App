﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooDAL;

#nullable disable

namespace ZooDAL.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    [Migration("20230614134356_FinallyInit")]
    partial class FinallyInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"),
                            Age = 2,
                            CategoryID = new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"),
                            Description = "Penguin description",
                            ImagePath = "10b02f99 - 82cb - 45a2 - 9f6f - 9ff5b93aecfa.jpg",
                            Name = "Penguin"
                        },
                        new
                        {
                            Id = new Guid("492db2e8-a2e5-45e1-85a1-58e2f3a206c5"),
                            Age = 5,
                            CategoryID = new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"),
                            Description = "Parrot description",
                            ImagePath = "a0b05188-fb1b-4409-8308-2a3e24d4ca9e.jpg",
                            Name = "Parrot"
                        },
                        new
                        {
                            Id = new Guid("c1f7583a-2949-46cb-9e82-12d8ec0fc3c9"),
                            Age = 3,
                            CategoryID = new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"),
                            Description = "Eagle description",
                            ImagePath = "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg",
                            Name = "Eagle"
                        },
                        new
                        {
                            Id = new Guid("c38f8d0b-3f7b-43c2-8117-86c3e39fe374"),
                            Age = 8,
                            CategoryID = new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"),
                            Description = "Chimpanzee description",
                            ImagePath = "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg",
                            Name = "Chimpanzee"
                        },
                        new
                        {
                            Id = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
                            Age = 12,
                            CategoryID = new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"),
                            Description = "Gorilla description",
                            ImagePath = "7741d954-515d-4222-a66b-d8f23273ea2c.jpg",
                            Name = "Gorilla"
                        },
                        new
                        {
                            Id = new Guid("16036593-0613-4393-9374-fb299389e960"),
                            Age = 10,
                            CategoryID = new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"),
                            Description = "Orangutan description",
                            ImagePath = "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg",
                            Name = "Orangutan"
                        },
                        new
                        {
                            Id = new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"),
                            Age = 4,
                            CategoryID = new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"),
                            Description = "Lion description",
                            ImagePath = "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg",
                            Name = "Lion"
                        },
                        new
                        {
                            Id = new Guid("8777a0f6-a25f-4757-b0f3-ec7d69cd0fa1"),
                            Age = 6,
                            CategoryID = new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"),
                            Description = "Cheetah description",
                            ImagePath = "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg",
                            Name = "Cheetah"
                        },
                        new
                        {
                            Id = new Guid("5fedfbff-9c1a-48dc-b381-aff5ef8f7b0f"),
                            Age = 7,
                            CategoryID = new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"),
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
                            Id = new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"),
                            Name = "Birds"
                        },
                        new
                        {
                            Id = new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"),
                            Name = "Monkeys"
                        },
                        new
                        {
                            Id = new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"),
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
                            Id = new Guid("4ccaa7ff-62b6-43c6-9b59-3bb91a13cabb"),
                            AnimalID = new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"),
                            Content = "This lion is amazing!"
                        },
                        new
                        {
                            Id = new Guid("bd4c78be-d484-487b-be58-eeffa37945cb"),
                            AnimalID = new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"),
                            Content = "The lion's majestic beauty is breathtaking!"
                        },
                        new
                        {
                            Id = new Guid("f67ad7fe-1151-4b14-a403-1e911f0b587c"),
                            AnimalID = new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"),
                            Content = "I'm in awe of this incredible lion!"
                        },
                        new
                        {
                            Id = new Guid("e5f0e819-2d01-4aae-949e-47f06d426cbd"),
                            AnimalID = new Guid("c1f7583a-2949-46cb-9e82-12d8ec0fc3c9"),
                            Content = "The eagle is soaring through the sky with grace!"
                        },
                        new
                        {
                            Id = new Guid("4ef1675e-3c4f-4435-a697-d9241086c891"),
                            AnimalID = new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"),
                            Content = "The penguin waddles with cuteness!"
                        },
                        new
                        {
                            Id = new Guid("e87faaa7-8b7d-4609-aef0-52b0e8950c13"),
                            AnimalID = new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"),
                            Content = "The penguin's sleek feathers are mesmerizing!"
                        },
                        new
                        {
                            Id = new Guid("f3fb2c6f-019b-470f-bcb1-a6b7e65df3bb"),
                            AnimalID = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
                            Content = "The gorilla's strength is awe-inspiring!"
                        },
                        new
                        {
                            Id = new Guid("497bb370-ba28-48cb-88b7-86957b659d3c"),
                            AnimalID = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
                            Content = "The gorilla's intelligence shines through!"
                        },
                        new
                        {
                            Id = new Guid("79487688-7f92-4861-a2e7-c0bc84ffd142"),
                            AnimalID = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
                            Content = "The gorilla's gentle nature is heartwarming!"
                        },
                        new
                        {
                            Id = new Guid("bb39c1ed-dcd0-4b7b-a384-ea04f57e1177"),
                            AnimalID = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
                            Content = "The gorilla's interactions with its family are fascinating!"
                        },
                        new
                        {
                            Id = new Guid("343cea39-c4ba-49fd-86fc-571fef39bc54"),
                            AnimalID = new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"),
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
