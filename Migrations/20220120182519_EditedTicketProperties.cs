using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class EditedTicketProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "SubmitterId");

            migrationBuilder.AddColumn<string>(
                name: "AssignedDevId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDevId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "SubmitterId",
                table: "Tickets",
                newName: "UserId");
        }
    }
}
