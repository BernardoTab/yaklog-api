using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YakLog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfolioToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioId = table.Column<long>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioId = table.Column<long>(type: "INTEGER", nullable: false),
                    Console = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Director = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesSeasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioId = table.Column<long>(type: "INTEGER", nullable: false),
                    SeasonNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesSeasons_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PortfolioId",
                table: "Books",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PortfolioId",
                table: "Games",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PortfolioId",
                table: "Movies",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PortfolioId",
                table: "Projects",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesSeasons_PortfolioId",
                table: "SeriesSeasons",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SeriesSeasons");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
