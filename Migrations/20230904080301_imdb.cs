using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moview.Migrations
{
    /// <inheritdoc />
    public partial class imdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IMDB",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDB",
                table: "Movies");
        }
    }
}
