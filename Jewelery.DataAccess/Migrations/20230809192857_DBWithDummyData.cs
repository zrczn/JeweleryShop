using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JeweleryShop.Migrations
{
    /// <inheritdoc />
    public partial class DBWithDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WearingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaterialsId = table.Column<int>(type: "int", nullable: false),
                    StonesId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stones_StonesId",
                        column: x => x.StonesId,
                        principalTable: "Stones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_WearingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WearingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Gold" },
                    { 2, "Platinum" }
                });

            migrationBuilder.InsertData(
                table: "Stones",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Diamond" }
                });

            migrationBuilder.InsertData(
                table: "WearingTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Neklace" },
                    { 2, "Ring" },
                    { 3, "Earrings" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURl", "MaterialsId", "Name", "Price", "Size", "StonesId", "TypeId" },
                values: new object[,]
                {
                    { 1, "Fine Craftsmansship", "<URL GOES HERE>", 1, "Golden Neklace", 350m, "300x300", 1, 1 },
                    { 2, "Fine Craftsmansship", "<URL GOES HERE>", 1, "Golden Ring", 100m, "300x300", 1, 2 },
                    { 3, "Fine Craftsmansship", "<URL GOES HERE>", 2, "Platinum Ring with Diamond", 100m, "300x300", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaterialsId",
                table: "Products",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StonesId",
                table: "Products",
                column: "StonesId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Stones");

            migrationBuilder.DropTable(
                name: "WearingTypes");
        }
    }
}
