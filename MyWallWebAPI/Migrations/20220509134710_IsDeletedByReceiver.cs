using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class IsDeletedByReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedBySender",
                table: "Message",
                newName: "IsDeletedBySender");

            migrationBuilder.RenameColumn(
                name: "DeletedByReceiver",
                table: "Message",
                newName: "IsDeletedByReceiver");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeletedBySender",
                table: "Message",
                newName: "DeletedBySender");

            migrationBuilder.RenameColumn(
                name: "IsDeletedByReceiver",
                table: "Message",
                newName: "DeletedByReceiver");
        }
    }
}
