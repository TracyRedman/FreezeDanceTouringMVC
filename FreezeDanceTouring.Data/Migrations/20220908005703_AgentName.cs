using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreezeDanceTouring.Data.Migrations
{
    public partial class AgentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "Artists");
        }
    }
}
