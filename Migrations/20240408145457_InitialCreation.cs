using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerTools.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Tools",
                newName: "FirstImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstImage",
                table: "Tools",
                newName: "Images");
        }
    }
}
