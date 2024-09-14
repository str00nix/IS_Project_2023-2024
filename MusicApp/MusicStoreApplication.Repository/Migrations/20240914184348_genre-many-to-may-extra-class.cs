using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStoreApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class genremanytomayextraclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "GenreOfTrack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreOfTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreOfTrack_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreOfTrack_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreOfTrack_GenreId",
                table: "GenreOfTrack",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreOfTrack_TrackId",
                table: "GenreOfTrack",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreOfTrack");

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
    }
}
