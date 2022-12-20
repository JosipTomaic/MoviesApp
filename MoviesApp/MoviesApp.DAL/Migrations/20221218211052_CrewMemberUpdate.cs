using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CrewMemberUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "CrewMember");

            migrationBuilder.DropColumn(
                name: "Deathday",
                table: "CrewMember");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CrewMember");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "CrewMember",
                newName: "Job");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Job",
                table: "CrewMember",
                newName: "Biography");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "CrewMember",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deathday",
                table: "CrewMember",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "CrewMember",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
