using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerId",
                table: "Teams",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Player_PlayerId",
                table: "Teams",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Player_PlayerId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PlayerId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Teams");
        }
    }
}
