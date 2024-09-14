using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class genrelistmanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Genre_GenreId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_GenreId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Tracks");

            migrationBuilder.AddColumn<Guid>(
                name: "TrackId",
                table: "Genre",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_TrackId",
                table: "Genre",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Tracks_TrackId",
                table: "Genre",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Tracks_TrackId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_TrackId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Genre");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
