using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class initiator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_IniciatorId",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "IniciatorId",
                table: "Chat",
                newName: "InitiatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_IniciatorId",
                table: "Chat",
                newName: "IX_Chat_InitiatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_InitiatorId",
                table: "Chat",
                column: "InitiatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_InitiatorId",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "InitiatorId",
                table: "Chat",
                newName: "IniciatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_InitiatorId",
                table: "Chat",
                newName: "IX_Chat_IniciatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_IniciatorId",
                table: "Chat",
                column: "IniciatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
