using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CrewMemberUpdatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "CrewMember");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "CrewMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
