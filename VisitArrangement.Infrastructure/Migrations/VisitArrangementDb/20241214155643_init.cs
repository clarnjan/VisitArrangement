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
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(450)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "varchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFK = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arrangement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorFK = table.Column<int>(type: "int", nullable: false),
                    HostFK = table.Column<int>(type: "int", nullable: false),
                    ApprovedByVisitor = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedByHost = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrangement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrangement_Users_HostFK",
                        column: x => x.HostFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arrangement_Users_VisitorFK",
                        column: x => x.VisitorFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentFromFK = table.Column<int>(type: "int", nullable: false),
                    SentToFK = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Users_SentFromFK",
                        column: x => x.SentFromFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_Users_SentToFK",
                        column: x => x.SentToFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFK = table.Column<int>(type: "int", nullable: false),
                    UserFK = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLocation_Location_LocationFK",
                        column: x => x.LocationFK,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLocation_Users_UserFK",
                        column: x => x.UserFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ByUserFK = table.Column<int>(type: "int", nullable: false),
                    ForUserFK = table.Column<int>(type: "int", nullable: false),
                    ArrangementFK = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<byte>(type: "tinyInt", nullable: false),
                    Comment = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Arrangement_ArrangementFK",
                        column: x => x.ArrangementFK,
                        principalTable: "Arrangement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Users_ByUserFK",
                        column: x => x.ByUserFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Users_ForUserFK",
                        column: x => x.ForUserFK,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrangement_HostFK",
                table: "Arrangement",
                column: "HostFK");

            migrationBuilder.CreateIndex(
                name: "IX_Arrangement_VisitorFK",
                table: "Arrangement",
                column: "VisitorFK");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SentFromFK",
                table: "Message",
                column: "SentFromFK");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SentToFK",
                table: "Message",
                column: "SentToFK");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ArrangementFK",
                table: "Review",
                column: "ArrangementFK");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ByUserFK",
                table: "Review",
                column: "ByUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ForUserFK",
                table: "Review",
                column: "ForUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocation_LocationFK",
                table: "UserLocation",
                column: "LocationFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocation_UserFK",
                table: "UserLocation",
                column: "UserFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "UserLocation");

            migrationBuilder.DropTable(
                name: "Arrangement");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
