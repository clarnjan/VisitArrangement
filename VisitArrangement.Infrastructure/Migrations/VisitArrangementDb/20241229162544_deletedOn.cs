using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    /// <inheritdoc />
    public partial class deletedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "varchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserLocation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserLocation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Review",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Message",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "LocationImage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Location",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Arrangement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocation_UserId",
                table: "UserLocation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocation_Users_UserId",
                table: "UserLocation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocation_Users_UserId",
                table: "UserLocation");

            migrationBuilder.DropIndex(
                name: "IX_UserLocation_UserId",
                table: "UserLocation");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserLocation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLocation");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "LocationImage");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Arrangement");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "varchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
