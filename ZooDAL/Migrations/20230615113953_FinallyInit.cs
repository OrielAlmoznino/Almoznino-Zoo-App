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
                    { new Guid("33d69f6a-2a30-4955-81b3-d849aff528e2"), "Birds" },
                    { new Guid("40f01712-a3f6-482a-ac23-d8f3940678bb"), "Monkeys" },
                    { new Guid("d9ccbfd0-5847-4c10-bec1-5f8ae48d5a77"), "Cats" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryID", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("0dbeb006-d74c-4bfd-90ea-48ecd6b5ceb0"), 6, new Guid("d9ccbfd0-5847-4c10-bec1-5f8ae48d5a77"), "Cheetah description", "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg", "Cheetah" },
                    { new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), 12, new Guid("40f01712-a3f6-482a-ac23-d8f3940678bb"), "Gorilla description", "7741d954-515d-4222-a66b-d8f23273ea2c.jpg", "Gorilla" },
                    { new Guid("36f30705-b073-479e-a238-2f8c9761fb2e"), 10, new Guid("40f01712-a3f6-482a-ac23-d8f3940678bb"), "Orangutan description", "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg", "Orangutan" },
                    { new Guid("5719bf16-429e-4b19-bcd3-8cb6656a44c0"), 8, new Guid("40f01712-a3f6-482a-ac23-d8f3940678bb"), "Chimpanzee description", "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg", "Chimpanzee" },
                    { new Guid("5e996328-3381-4409-b23d-7196209012fe"), 2, new Guid("33d69f6a-2a30-4955-81b3-d849aff528e2"), "Penguin description", "10b02f99-82cb-45a2-9f6f-9ff5b93aecfa.jpg", "Penguin" },
                    { new Guid("85350b43-d2a7-4caa-9669-c5d75b721f43"), 3, new Guid("33d69f6a-2a30-4955-81b3-d849aff528e2"), "Eagle description", "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg", "Eagle" },
                    { new Guid("8c3103bf-3cfc-49b2-9b78-1aa9f2b5aea1"), 4, new Guid("d9ccbfd0-5847-4c10-bec1-5f8ae48d5a77"), "Lion description", "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg", "Lion" },
                    { new Guid("cd84bd40-9bbb-4268-8c5c-ce13a72e2cff"), 7, new Guid("d9ccbfd0-5847-4c10-bec1-5f8ae48d5a77"), "Tiger description", "d15b6b92-391b-43ea-a55f-31e8f4cd163f.jpg", "Tiger" },
                    { new Guid("fd1caf0a-8a78-4632-86b3-9eaff1a8dddf"), 5, new Guid("33d69f6a-2a30-4955-81b3-d849aff528e2"), "Parrot description", "9a711fee-6d32-4ed0-b1d6-a5f4958d2208.jpg", "Parrot" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnimalID", "Content" },
                values: new object[,]
                {
                    { new Guid("0de264fc-ad18-4dfe-b315-cc6ae8231012"), new Guid("5e996328-3381-4409-b23d-7196209012fe"), "The penguin waddles with cuteness!" },
                    { new Guid("14ce98f9-70bf-4601-b881-b0ac5386d01d"), new Guid("8c3103bf-3cfc-49b2-9b78-1aa9f2b5aea1"), "This lion is amazing!" },
                    { new Guid("17d73aaf-314d-4396-a8cf-777dbafafbed"), new Guid("5e996328-3381-4409-b23d-7196209012fe"), "The penguin's sleek feathers are mesmerizing!" },
                    { new Guid("1d350238-43e6-4032-85ba-507ec622ac9d"), new Guid("8c3103bf-3cfc-49b2-9b78-1aa9f2b5aea1"), "The lion's majestic beauty is breathtaking!" },
                    { new Guid("1d3a5e5d-aaa8-43ef-809b-a53b1c9c691f"), new Guid("85350b43-d2a7-4caa-9669-c5d75b721f43"), "The eagle is soaring through the sky with grace!" },
                    { new Guid("2bbaed1f-9090-40d7-85cf-9db04635c7e3"), new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), "The gorilla's intelligence shines through!" },
                    { new Guid("44230bb6-9718-43bd-a254-21c1e34c125a"), new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), "The gorilla's gentle nature is heartwarming!" },
                    { new Guid("593568f8-3865-47a0-a241-b95cdf19d944"), new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), "The gorilla's strength is awe-inspiring!" },
                    { new Guid("73703a8a-98a9-4495-9b8f-dfa539a5ca0a"), new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), "The gorilla's expressive eyes captivate everyone!" },
                    { new Guid("7db87dcc-c4a5-4e6c-ace5-f10afc3eae48"), new Guid("34ec3b43-b086-4004-a5c3-d3e072ff4e0a"), "The gorilla's interactions with its family are fascinating!" },
                    { new Guid("f52937b1-533b-4f5b-a9d2-f79dfbc8f463"), new Guid("8c3103bf-3cfc-49b2-9b78-1aa9f2b5aea1"), "I'm in awe of this incredible lion!" }
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
