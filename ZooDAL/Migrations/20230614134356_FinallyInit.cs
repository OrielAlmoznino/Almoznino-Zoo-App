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
                    { new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"), "Monkeys" },
                    { new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"), "Cats" },
                    { new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"), "Birds" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CategoryID", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("16036593-0613-4393-9374-fb299389e960"), 10, new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"), "Orangutan description", "0ed86487-a07f-4c21-8fb8-3751215bef68.jpg", "Orangutan" },
                    { new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"), 2, new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"), "Penguin description", "10b02f99-82cb-45a2-9f6f-9ff5b93aecfa.jpg", "Penguin" },
                    { new Guid("492db2e8-a2e5-45e1-85a1-58e2f3a206c5"), 5, new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"), "Parrot description", "a0b05188-fb1b-4409-8308-2a3e24d4ca9e.jpg", "Parrot" },
                    { new Guid("5fedfbff-9c1a-48dc-b381-aff5ef8f7b0f"), 7, new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"), "Tiger description", "d15b6b92-391b-43ea-a55f-31e8f4cd163f.jpg", "Tiger" },
                    { new Guid("8777a0f6-a25f-4757-b0f3-ec7d69cd0fa1"), 6, new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"), "Cheetah description", "433a2c09-520b-48c1-a7bc-1e6b9c62ba12.jpg", "Cheetah" },
                    { new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), 12, new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"), "Gorilla description", "7741d954-515d-4222-a66b-d8f23273ea2c.jpg", "Gorilla" },
                    { new Guid("c1f7583a-2949-46cb-9e82-12d8ec0fc3c9"), 3, new Guid("ca3c26b5-b4de-4609-b12f-0ddfd10a6b89"), "Eagle description", "4eb9ea13-b0c3-4144-be0c-0d1eff68aa7b.jpg", "Eagle" },
                    { new Guid("c38f8d0b-3f7b-43c2-8117-86c3e39fe374"), 8, new Guid("30a677e5-51c8-4240-a8a6-7f3b986290b2"), "Chimpanzee description", "475027aa-44ba-4ce3-8a75-b3c261599b0d.jpg", "Chimpanzee" },
                    { new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"), 4, new Guid("55312742-a7eb-4e65-9455-a2d00c0ab042"), "Lion description", "2021be47-0f90-4053-bb1a-d939bde5bc7f.jpg", "Lion" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AnimalID", "Content" },
                values: new object[,]
                {
                    { new Guid("343cea39-c4ba-49fd-86fc-571fef39bc54"), new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), "The gorilla's expressive eyes captivate everyone!" },
                    { new Guid("497bb370-ba28-48cb-88b7-86957b659d3c"), new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), "The gorilla's intelligence shines through!" },
                    { new Guid("4ccaa7ff-62b6-43c6-9b59-3bb91a13cabb"), new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"), "This lion is amazing!" },
                    { new Guid("4ef1675e-3c4f-4435-a697-d9241086c891"), new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"), "The penguin waddles with cuteness!" },
                    { new Guid("79487688-7f92-4861-a2e7-c0bc84ffd142"), new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), "The gorilla's gentle nature is heartwarming!" },
                    { new Guid("bb39c1ed-dcd0-4b7b-a384-ea04f57e1177"), new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), "The gorilla's interactions with its family are fascinating!" },
                    { new Guid("bd4c78be-d484-487b-be58-eeffa37945cb"), new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"), "The lion's majestic beauty is breathtaking!" },
                    { new Guid("e5f0e819-2d01-4aae-949e-47f06d426cbd"), new Guid("c1f7583a-2949-46cb-9e82-12d8ec0fc3c9"), "The eagle is soaring through the sky with grace!" },
                    { new Guid("e87faaa7-8b7d-4609-aef0-52b0e8950c13"), new Guid("21ff3c66-77cc-4bfd-a03c-58e6c330f9da"), "The penguin's sleek feathers are mesmerizing!" },
                    { new Guid("f3fb2c6f-019b-470f-bcb1-a6b7e65df3bb"), new Guid("99fcacd2-0809-4d13-8b7d-a49fdb87ed2d"), "The gorilla's strength is awe-inspiring!" },
                    { new Guid("f67ad7fe-1151-4b14-a403-1e911f0b587c"), new Guid("ded177ed-d47b-4de1-9aa7-d6e20a204a79"), "I'm in awe of this incredible lion!" }
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
