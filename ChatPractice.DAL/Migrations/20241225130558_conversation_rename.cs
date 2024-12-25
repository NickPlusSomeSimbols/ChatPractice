using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatPractice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class conversation_rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_conversation",
                table: "conversation");

            migrationBuilder.RenameTable(
                name: "conversation",
                newName: "dialogue");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "message",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_UserTwoId",
                table: "dialogue",
                newName: "IX_dialogue_UserTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_UserOneId",
                table: "dialogue",
                newName: "IX_dialogue_UserOneId");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_UserId",
                table: "dialogue",
                newName: "IX_dialogue_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_conversation_IsDeleted",
                table: "dialogue",
                newName: "IX_dialogue_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dialogue",
                table: "dialogue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dialogue_user_UserId",
                table: "dialogue",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dialogue_user_UserOneId",
                table: "dialogue",
                column: "UserOneId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dialogue_user_UserTwoId",
                table: "dialogue",
                column: "UserTwoId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_message_dialogue_DialogueId",
                table: "message",
                column: "DialogueId",
                principalTable: "dialogue",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dialogue_user_UserId",
                table: "dialogue");

            migrationBuilder.DropForeignKey(
                name: "FK_dialogue_user_UserOneId",
                table: "dialogue");

            migrationBuilder.DropForeignKey(
                name: "FK_dialogue_user_UserTwoId",
                table: "dialogue");

            migrationBuilder.DropForeignKey(
                name: "FK_message_dialogue_DialogueId",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dialogue",
                table: "dialogue");

            migrationBuilder.RenameTable(
                name: "dialogue",
                newName: "conversation");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "message",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_dialogue_UserTwoId",
                table: "conversation",
                newName: "IX_conversation_UserTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_dialogue_UserOneId",
                table: "conversation",
                newName: "IX_conversation_UserOneId");

            migrationBuilder.RenameIndex(
                name: "IX_dialogue_UserId",
                table: "conversation",
                newName: "IX_conversation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_dialogue_IsDeleted",
                table: "conversation",
                newName: "IX_conversation_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_conversation",
                table: "conversation",
                column: "Id");

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
    }
}
