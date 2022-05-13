using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_Project.Data.Migrations
{
    public partial class AddColumnInFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkFilmPlayer",
                schema: "Film",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkFilmPlayer",
                schema: "Film",
                table: "Films");
        }
    }
}