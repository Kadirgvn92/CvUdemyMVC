using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvUdemyMVC.DataAccessLayer.Migrations
{
    public partial class mig_add_hobby_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description4",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description3",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "Description4",
                table: "Hobbies");
        }
    }
}
