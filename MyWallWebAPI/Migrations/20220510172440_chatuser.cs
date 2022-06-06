using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class chatuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Chat_ChatTypeId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "ChatTypeId",
                table: "Chat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatTypeId",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat",
                column: "ChatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Chat_ChatTypeId",
                table: "Chat",
                column: "ChatTypeId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
