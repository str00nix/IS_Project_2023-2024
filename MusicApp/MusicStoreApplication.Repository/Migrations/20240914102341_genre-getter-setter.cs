using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class genregettersetter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genre");
        }
    }
}
