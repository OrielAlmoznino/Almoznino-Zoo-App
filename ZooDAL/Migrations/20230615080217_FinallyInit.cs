using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooDAL.Migrations
{
    /// <inheritdoc />
    public partial class FinallyInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"), "Cats" },
                    { new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"), "Birds" },
                    { new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"), "Monkeys" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryID", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"), 2, new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"), "Penguin description", "10b02f99-82cb-45a2-9f6f-9ff5b93aecfa.jpg", "Penguin" },
                    { new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), 12, new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"), "Gorilla description", "7741d954-515d-4222-a66b-d8f23273ea2c.jpg", "Gorilla" },
                    { new Guid("5bd37101-03a7-4862-b330-4663b0da880a"), 8, new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"), "Chimpanzee description", "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg", "Chimpanzee" },
                    { new Guid("8944349c-5d99-4eb1-bd74-5572f99c49fd"), 10, new Guid("b23b8e9d-50de-44ae-a7ad-c73053b1ba06"), "Orangutan description", "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg", "Orangutan" },
                    { new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"), 4, new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"), "Lion description", "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg", "Lion" },
                    { new Guid("9a711fee-6d32-4ed0-b1d6-a5f4958d2208"), 5, new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"), "Parrot description", "492db2e8-a2e5-45e1-85a1-58e2f3a206c5.jpg", "Parrot" },
                    { new Guid("c49c8581-5aee-4085-99e5-99dbc20ff046"), 6, new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"), "Cheetah description", "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg", "Cheetah" },
                    { new Guid("cf058ebc-a989-441a-b89b-5a0de8e95e13"), 3, new Guid("597a4fa6-2039-49b1-8679-9fcba9d43786"), "Eagle description", "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg", "Eagle" },
                    { new Guid("e080540d-e961-44a3-ac92-304a0832f47a"), 7, new Guid("520b44cf-16f8-4625-a3b8-8864bc9fa57f"), "Tiger description", "d15b6b92-391b-43ea-a55f-31e8f4cd163f.jpg", "Tiger" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnimalID", "Content" },
                values: new object[,]
                {
                    { new Guid("0c4831d4-ec24-476e-bf87-ed957dcb4e4a"), new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), "The gorilla's interactions with its family are fascinating!" },
                    { new Guid("0eb588ee-c116-483b-9175-87f589f8253c"), new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"), "The penguin waddles with cuteness!" },
                    { new Guid("28d71b5e-bdff-42ad-b050-c849f4b38dbc"), new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"), "The lion's majestic beauty is breathtaking!" },
                    { new Guid("3899a556-78e1-42a9-be13-4e0e13842fff"), new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), "The gorilla's strength is awe-inspiring!" },
                    { new Guid("4647eac2-85b3-45a4-9447-8d3b7671d585"), new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), "The gorilla's intelligence shines through!" },
                    { new Guid("53f90afa-3174-40b7-a016-cc574188c191"), new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), "The gorilla's expressive eyes captivate everyone!" },
                    { new Guid("70fdc07c-9370-4451-963a-93d3fb378de4"), new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"), "I'm in awe of this incredible lion!" },
                    { new Guid("847a785c-c237-494e-9749-b5506497b9e8"), new Guid("03e0bc3e-54ed-4fe9-9894-f6f80a3c8e5a"), "The penguin's sleek feathers are mesmerizing!" },
                    { new Guid("91431acc-3f1e-4468-bb07-a05c4428110d"), new Guid("cf058ebc-a989-441a-b89b-5a0de8e95e13"), "The eagle is soaring through the sky with grace!" },
                    { new Guid("d23ad862-00da-4ec9-9219-ae677fed792b"), new Guid("361c8cde-8213-4466-b124-0729d2f9cb5e"), "The gorilla's gentle nature is heartwarming!" },
                    { new Guid("e96e9520-1b38-4c4e-8a31-ed7a3cc42d58"), new Guid("8c414e57-752a-4f01-8ff2-750353f0dc79"), "This lion is amazing!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryID",
                table: "Animals",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalID",
                table: "Comments",
                column: "AnimalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
