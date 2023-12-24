using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvUdemyMVC.DataAccessLayer.Migrations
{
    public partial class mig_add_skill_percentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Percentage",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Skills");
        }
    }
}
