using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Hero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Card1 = table.Column<string>(nullable: true),
                    Card2 = table.Column<string>(nullable: true),
                    Card3 = table.Column<string>(nullable: true),
                    Card4 = table.Column<string>(nullable: true),
                    DeathToken = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heros_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heros_TeamId",
                table: "Heros",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heros");
        }
    }
}
