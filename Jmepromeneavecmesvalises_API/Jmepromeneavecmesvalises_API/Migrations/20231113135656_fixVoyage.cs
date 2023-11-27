using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    /// <inheritdoc />
    public partial class fixVoyage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Voyage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Voyage");
        }
    }
}
