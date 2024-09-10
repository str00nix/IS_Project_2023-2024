using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrackDurationInMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DurationInMilliseconds",
                table: "Tracks",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMilliseconds",
                table: "Tracks");
        }
    }
}
