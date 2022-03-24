using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course_Project.Data.Migrations
{
    public partial class FilmBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Film");

            migrationBuilder.CreateTable(
                name: "Actors",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Countries = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeLimit = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageManagers",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageManagers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmCountries",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Film",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmCountries_Films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "Film",
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmRoles",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmRoles_Actors_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "Film",
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmRoles_Films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "Film",
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "Film",
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "Film",
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmStageManagers",
                schema: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageManagerId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStageManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmStageManagers_Films_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "Film",
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmStageManagers_StageManagers_StageManagerId",
                        column: x => x.StageManagerId,
                        principalSchema: "Film",
                        principalTable: "StageManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCountries_CountryId",
                schema: "Film",
                table: "FilmCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCountries_FilmId",
                schema: "Film",
                table: "FilmCountries",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_FilmId",
                schema: "Film",
                table: "FilmGenres",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_GenreId",
                schema: "Film",
                table: "FilmGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmRoles_ActorId",
                schema: "Film",
                table: "FilmRoles",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmRoles_FilmId",
                schema: "Film",
                table: "FilmRoles",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStageManagers_FilmId",
                schema: "Film",
                table: "FilmStageManagers",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStageManagers_StageManagerId",
                schema: "Film",
                table: "FilmStageManagers",
                column: "StageManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCountries",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "FilmGenres",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "FilmRoles",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "FilmStageManagers",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "Actors",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "Films",
                schema: "Film");

            migrationBuilder.DropTable(
                name: "StageManagers",
                schema: "Film");
        }
    }
}
