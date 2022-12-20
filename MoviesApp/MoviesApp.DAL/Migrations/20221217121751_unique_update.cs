using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class uniqueupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movie_TmbdId",
                table: "Movie",
                column: "TmbdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_TmdbId",
                table: "Genre",
                column: "TmdbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_TmdbId",
                table: "CrewMember",
                column: "TmdbId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movie_TmbdId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Genre_TmdbId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_CrewMember_TmdbId",
                table: "CrewMember");
        }
    }
}
