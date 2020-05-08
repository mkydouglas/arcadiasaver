using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class PlayerTeamRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerId",
                table: "Teams",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_PlayerId",
                table: "Teams",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_PlayerId",
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
