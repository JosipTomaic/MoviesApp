using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CrewMemberUpdatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CrewMember_TmdbId",
                table: "CrewMember");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_TmdbId",
                table: "CrewMember",
                column: "TmdbId",
                unique: true);
        }
    }
}
