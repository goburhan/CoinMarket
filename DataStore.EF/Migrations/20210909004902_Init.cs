using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStore.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "Name", "Price", "Symbol" },
                values: new object[] { 1, "Bitcoin", 50.0, "BTC" });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "Name", "Price", "Symbol" },
                values: new object[] { 2, "Ethereum", 4000.0, "ETH" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
