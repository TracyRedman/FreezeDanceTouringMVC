using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreezeDanceTouring.Data.Migrations
{
    public partial class Agent_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "Agents");
        }
    }
}
