using Microsoft.EntityFrameworkCore.Migrations;

namespace protostream.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    film = table.Column<string>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    leadStudio = table.Column<string>(nullable: true),
                    audienceScore = table.Column<byte>(nullable: false),
                    profitability = table.Column<decimal>(nullable: false),
                    rottenTomatoes = table.Column<byte>(nullable: false),
                    worldwideGross = table.Column<decimal>(nullable: false),
                    year = table.Column<ushort>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
