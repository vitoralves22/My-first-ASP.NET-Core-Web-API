using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class deletedbyreceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswer",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsDeletedByReceiver",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Message");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedByReceiver",
                table: "MessageReceiver",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "MessageReceiver",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeletedByReceiver",
                table: "MessageReceiver");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "MessageReceiver");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "Message",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedByReceiver",
                table: "Message",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Message",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
