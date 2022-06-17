using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class ChatInvitationTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvite_AspNetUsers_ReceiverId",
                table: "ChatInvite");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvite_AspNetUsers_SenderId",
                table: "ChatInvite");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvite_Chat_ChatId",
                table: "ChatInvite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatInvite",
                table: "ChatInvite");

            migrationBuilder.RenameTable(
                name: "ChatInvite",
                newName: "ChatInvitation");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvite_SenderId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvite_ReceiverId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvite_ChatId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatInvitation",
                table: "ChatInvitation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_AspNetUsers_ReceiverId",
                table: "ChatInvitation",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_AspNetUsers_SenderId",
                table: "ChatInvitation",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_Chat_ChatId",
                table: "ChatInvitation",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_AspNetUsers_ReceiverId",
                table: "ChatInvitation");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_AspNetUsers_SenderId",
                table: "ChatInvitation");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_Chat_ChatId",
                table: "ChatInvitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatInvitation",
                table: "ChatInvitation");

            migrationBuilder.RenameTable(
                name: "ChatInvitation",
                newName: "ChatInvite");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_SenderId",
                table: "ChatInvite",
                newName: "IX_ChatInvite_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_ReceiverId",
                table: "ChatInvite",
                newName: "IX_ChatInvite_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_ChatId",
                table: "ChatInvite",
                newName: "IX_ChatInvite_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatInvite",
                table: "ChatInvite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvite_AspNetUsers_ReceiverId",
                table: "ChatInvite",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvite_AspNetUsers_SenderId",
                table: "ChatInvite",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvite_Chat_ChatId",
                table: "ChatInvite",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
