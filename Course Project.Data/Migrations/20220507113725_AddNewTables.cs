using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_Project.Data.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmRatings",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmRatings_Films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "Film",
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalSchema: "Film",
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmRatings_FilmId",
                schema: "Film",
                table: "FilmRatings",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmRatings_RatingId",
                schema: "Film",
                table: "FilmRatings",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmRatings",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "Ratings",
                schema: "Film");
        }
    }
}
