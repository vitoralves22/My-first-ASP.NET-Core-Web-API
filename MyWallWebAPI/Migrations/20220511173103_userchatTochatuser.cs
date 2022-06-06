using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class userchatTochatuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_AspNetUsers_ApplicationUserId",
                table: "UserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Chat_ChatId",
                table: "UserChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat");

            migrationBuilder.RenameTable(
                name: "UserChat",
                newName: "ChatUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserChat_ApplicationUserId",
                table: "ChatUser",
                newName: "IX_ChatUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser",
                columns: new[] { "ChatId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_AspNetUsers_ApplicationUserId",
                table: "ChatUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chat_ChatId",
                table: "ChatUser",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_AspNetUsers_ApplicationUserId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chat_ChatId",
                table: "ChatUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser");

            migrationBuilder.RenameTable(
                name: "ChatUser",
                newName: "UserChat");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_ApplicationUserId",
                table: "UserChat",
                newName: "IX_UserChat_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat",
                columns: new[] { "ChatId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_AspNetUsers_ApplicationUserId",
                table: "UserChat",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Chat_ChatId",
                table: "UserChat",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
