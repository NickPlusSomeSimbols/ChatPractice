using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatPractice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_conversation_ConversationId",
                table: "message");

            migrationBuilder.DropTable(
                name: "ConversationUser");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "message",
                newName: "DialogueId");

            migrationBuilder.RenameIndex(
                name: "IX_message_ConversationId",
                table: "message",
                newName: "IX_message_DialogueId");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "conversation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserOneId",
                table: "conversation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserTwoId",
                table: "conversation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_conversation_UserId",
                table: "conversation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_UserOneId",
                table: "conversation",
                column: "UserOneId");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_UserTwoId",
                table: "conversation",
                column: "UserTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_conversation_user_UserId",
                table: "conversation",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_conversation_user_UserOneId",
                table: "conversation",
                column: "UserOneId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conversation_user_UserTwoId",
                table: "conversation",
                column: "UserTwoId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_message_conversation_DialogueId",
                table: "message",
                column: "DialogueId",
                principalTable: "conversation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conversation_user_UserId",
                table: "conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_conversation_user_UserOneId",
                table: "conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_conversation_user_UserTwoId",
                table: "conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_message_conversation_DialogueId",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_conversation_UserId",
                table: "conversation");

            migrationBuilder.DropIndex(
                name: "IX_conversation_UserOneId",
                table: "conversation");

            migrationBuilder.DropIndex(
                name: "IX_conversation_UserTwoId",
                table: "conversation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "conversation");

            migrationBuilder.DropColumn(
                name: "UserOneId",
                table: "conversation");

            migrationBuilder.DropColumn(
                name: "UserTwoId",
                table: "conversation");

            migrationBuilder.RenameColumn(
                name: "DialogueId",
                table: "message",
                newName: "ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_message_DialogueId",
                table: "message",
                newName: "IX_message_ConversationId");

            migrationBuilder.CreateTable(
                name: "ConversationUser",
                columns: table => new
                {
                    ConversationsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationUser", x => new { x.ConversationsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ConversationUser_conversation_ConversationsId",
                        column: x => x.ConversationsId,
                        principalTable: "conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationUser_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationUser_UsersId",
                table: "ConversationUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_message_conversation_ConversationId",
                table: "message",
                column: "ConversationId",
                principalTable: "conversation",
                principalColumn: "Id");
        }
    }
}
