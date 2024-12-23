using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatPractice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class basic_configuration_setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUser_Conversations_ConversationsId",
                table: "ConversationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUser_Users_UsersId",
                table: "ConversationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_UserId",
                table: "UserSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSessions",
                table: "UserSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversations",
                table: "Conversations");

            migrationBuilder.RenameTable(
                name: "UserSessions",
                newName: "user_session");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "message");

            migrationBuilder.RenameTable(
                name: "Conversations",
                newName: "conversation");

            migrationBuilder.RenameIndex(
                name: "IX_UserSessions_UserId",
                table: "user_session",
                newName: "IX_user_session_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ConversationId",
                table: "message",
                newName: "IX_message_ConversationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "message",
                type: "character varying(32768)",
                maxLength: 32768,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_session",
                table: "user_session",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_conversation",
                table: "conversation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_session_IsDeleted",
                table: "user_session",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_user_IsDeleted",
                table: "user",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_message_IsDeleted",
                table: "message",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_IsDeleted",
                table: "conversation",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUser_conversation_ConversationsId",
                table: "ConversationUser",
                column: "ConversationsId",
                principalTable: "conversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUser_user_UsersId",
                table: "ConversationUser",
                column: "UsersId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_conversation_ConversationId",
                table: "message",
                column: "ConversationId",
                principalTable: "conversation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_session_user_UserId",
                table: "user_session",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUser_conversation_ConversationsId",
                table: "ConversationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUser_user_UsersId",
                table: "ConversationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_message_conversation_ConversationId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_user_session_user_UserId",
                table: "user_session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_session",
                table: "user_session");

            migrationBuilder.DropIndex(
                name: "IX_user_session_IsDeleted",
                table: "user_session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_IsDeleted",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_message_IsDeleted",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_conversation",
                table: "conversation");

            migrationBuilder.DropIndex(
                name: "IX_conversation_IsDeleted",
                table: "conversation");

            migrationBuilder.RenameTable(
                name: "user_session",
                newName: "UserSessions");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "conversation",
                newName: "Conversations");

            migrationBuilder.RenameIndex(
                name: "IX_user_session_UserId",
                table: "UserSessions",
                newName: "IX_UserSessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_message_ConversationId",
                table: "Messages",
                newName: "IX_Messages_ConversationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Messages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32768)",
                oldMaxLength: 32768);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSessions",
                table: "UserSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conversations",
                table: "Conversations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUser_Conversations_ConversationsId",
                table: "ConversationUser",
                column: "ConversationsId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUser_Users_UsersId",
                table: "ConversationUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_UserId",
                table: "UserSessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
