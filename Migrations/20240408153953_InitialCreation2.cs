using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerTools.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FifthSpecs",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FourthSpecs",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondSpecs",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SixthSpecs",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdSpecs",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FifthSpecs",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "FourthSpecs",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "SecondSpecs",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "SixthSpecs",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ThirdSpecs",
                table: "Tools");
        }
    }
}
