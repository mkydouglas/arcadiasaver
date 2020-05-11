using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Phases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phase_Campaigns_CampaignId",
                table: "Phase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phase",
                table: "Phase");

            migrationBuilder.RenameTable(
                name: "Phase",
                newName: "Phases");

            migrationBuilder.RenameIndex(
                name: "IX_Phase_CampaignId",
                table: "Phases",
                newName: "IX_Phases_CampaignId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phases",
                table: "Phases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Campaigns_CampaignId",
                table: "Phases",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phases_Campaigns_CampaignId",
                table: "Phases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phases",
                table: "Phases");

            migrationBuilder.RenameTable(
                name: "Phases",
                newName: "Phase");

            migrationBuilder.RenameIndex(
                name: "IX_Phases_CampaignId",
                table: "Phase",
                newName: "IX_Phase_CampaignId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phase",
                table: "Phase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phase_Campaigns_CampaignId",
                table: "Phase",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
