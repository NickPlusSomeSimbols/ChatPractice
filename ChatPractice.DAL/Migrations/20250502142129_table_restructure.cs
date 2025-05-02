using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChatPractice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class table_restructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_dialogue_DialogueId",
                table: "message");

            migrationBuilder.DropTable(
                name: "dialogue");

            migrationBuilder.DropIndex(
                name: "IX_message_DialogueId",
                table: "message");

            migrationBuilder.DropColumn(
                name: "DialogueId",
                table: "message");

            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "message",
                newName: "SendingDate");

            migrationBuilder.AddColumn<long>(
                name: "ReceieverId",
                table: "message",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceieverId",
                table: "message");

            migrationBuilder.RenameColumn(
                name: "SendingDate",
                table: "message",
                newName: "PostDate");

            migrationBuilder.AddColumn<long>(
                name: "DialogueId",
                table: "message",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dialogue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserOneId = table.Column<long>(type: "bigint", nullable: false),
                    UserTwoId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dialogue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dialogue_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dialogue_user_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dialogue_user_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_message_DialogueId",
                table: "message",
                column: "DialogueId");

            migrationBuilder.CreateIndex(
                name: "IX_dialogue_IsDeleted",
                table: "dialogue",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_dialogue_UserId",
                table: "dialogue",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dialogue_UserOneId",
                table: "dialogue",
                column: "UserOneId");

            migrationBuilder.CreateIndex(
                name: "IX_dialogue_UserTwoId",
                table: "dialogue",
                column: "UserTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_message_dialogue_DialogueId",
                table: "message",
                column: "DialogueId",
                principalTable: "dialogue",
                principalColumn: "Id");
        }
    }
}
