using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallWebAPI.Migrations
{
    public partial class messagereceivers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IniciatorId",
                table: "Chat",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MessageReceiver",
                columns: table => new
                {
                    ReceiverId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiver", x => new { x.ReceiverId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_MessageReceiver_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReceiver_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_IniciatorId",
                table: "Chat",
                column: "IniciatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiver_MessageId",
                table: "MessageReceiver",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_IniciatorId",
                table: "Chat",
                column: "IniciatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_IniciatorId",
                table: "Chat");

            migrationBuilder.DropTable(
                name: "MessageReceiver");

            migrationBuilder.DropIndex(
                name: "IX_Chat_IniciatorId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "IniciatorId",
                table: "Chat");
        }
    }
}
