using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_Project.Data.Migrations
{
    public partial class AddNewColumnInTableFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkFilmtrailer",
                schema: "Film",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkFilmtrailer",
                schema: "Film",
                table: "Films");
        }
    }
}
