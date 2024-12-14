using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    /// <inheritdoc />
    public partial class userTableProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrangement_User_HostFK",
                table: "Arrangement");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrangement_User_VisitorFK",
                table: "Arrangement");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_SentFromFK",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_SentToFK",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ByUserFK",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ForUserFK",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocation_User_UserFK",
                table: "UserLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangement_Users_HostFK",
                table: "Arrangement",
                column: "HostFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangement_Users_VisitorFK",
                table: "Arrangement",
                column: "VisitorFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SentFromFK",
                table: "Message",
                column: "SentFromFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SentToFK",
                table: "Message",
                column: "SentToFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_ByUserFK",
                table: "Review",
                column: "ByUserFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_ForUserFK",
                table: "Review",
                column: "ForUserFK",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocation_Users_UserFK",
                table: "UserLocation",
                column: "UserFK",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrangement_Users_HostFK",
                table: "Arrangement");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrangement_Users_VisitorFK",
                table: "Arrangement");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_SentFromFK",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_SentToFK",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_ByUserFK",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_ForUserFK",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocation_Users_UserFK",
                table: "UserLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangement_User_HostFK",
                table: "Arrangement",
                column: "HostFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrangement_User_VisitorFK",
                table: "Arrangement",
                column: "VisitorFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SentFromFK",
                table: "Message",
                column: "SentFromFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SentToFK",
                table: "Message",
                column: "SentToFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ByUserFK",
                table: "Review",
                column: "ByUserFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ForUserFK",
                table: "Review",
                column: "ForUserFK",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocation_User_UserFK",
                table: "UserLocation",
                column: "UserFK",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
