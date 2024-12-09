using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(450)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(450)", nullable: true),
                    Email = table.Column<string>(type: "varchar(450)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(450)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(450)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(450)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentFromFK = table.Column<int>(type: "int", nullable: false),
                    SentToFK = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", nullable: false),
                    SentFromId = table.Column<string>(type: "varchar(450)", nullable: true),
                    SentToId = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_User_SentFromId",
                        column: x => x.SentFromId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_User_SentToId",
                        column: x => x.SentToId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_SentFromId",
                table: "Recipes",
                column: "SentFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_SentToId",
                table: "Recipes",
                column: "SentToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
