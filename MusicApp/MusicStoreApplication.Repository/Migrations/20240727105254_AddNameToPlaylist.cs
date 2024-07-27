using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Playlists");
        }
    }
}
