using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    /// <inheritdoc />
    public partial class message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_User_SentFromId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_User_SentToId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_SentToId",
                table: "Message",
                newName: "IX_Message_SentToId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_SentFromId",
                table: "Message",
                newName: "IX_Message_SentFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SentFromId",
                table: "Message",
                column: "SentFromId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SentToId",
                table: "Message",
                column: "SentToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_SentFromId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_SentToId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Recipes");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SentToId",
                table: "Recipes",
                newName: "IX_Recipes_SentToId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SentFromId",
                table: "Recipes",
                newName: "IX_Recipes_SentFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_User_SentFromId",
                table: "Recipes",
                column: "SentFromId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_User_SentToId",
                table: "Recipes",
                column: "SentToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
