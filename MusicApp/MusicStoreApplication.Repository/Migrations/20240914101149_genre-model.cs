using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class genremodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Tracks");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_GenreId",
                table: "Tracks",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Genre_GenreId",
                table: "Tracks",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Genre_GenreId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_GenreId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Tracks");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
