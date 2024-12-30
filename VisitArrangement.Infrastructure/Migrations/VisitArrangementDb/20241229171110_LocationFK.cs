using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitArrangement.Infrastructure.Migrations.VisitArrangementDb
{
    /// <inheritdoc />
    public partial class LocationFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage");

            migrationBuilder.DropIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "LocationImage");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationFK",
                table: "LocationImage",
                column: "LocationFK");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Location_LocationFK",
                table: "LocationImage",
                column: "LocationFK",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationImage_Location_LocationFK",
                table: "LocationImage");

            migrationBuilder.DropIndex(
                name: "IX_LocationImage_LocationFK",
                table: "LocationImage");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "LocationImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationImage_Location_LocationId",
                table: "LocationImage",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
