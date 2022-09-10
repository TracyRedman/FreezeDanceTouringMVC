using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreezeDanceTouring.Data.Migrations
{
    public partial class VenueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Venues_VenueName",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "VenueName",
                table: "Shows",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_VenueName",
                table: "Shows",
                newName: "IX_Shows_VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Venues_VenueId",
                table: "Shows",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Venues_VenueId",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Shows",
                newName: "VenueName");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_VenueId",
                table: "Shows",
                newName: "IX_Shows_VenueName");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Venues_VenueName",
                table: "Shows",
                column: "VenueName",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
