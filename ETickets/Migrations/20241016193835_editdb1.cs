using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class editdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovie_Actors_ActorId",
                table: "ActorsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovie_Movies_MovieId",
                table: "ActorsMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsMovie",
                table: "ActorsMovie");

            migrationBuilder.RenameTable(
                name: "ActorsMovie",
                newName: "ActorMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovie_MovieId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovie_ActorId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "ActorMovies",
                newName: "ActorsMovie");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_MovieId",
                table: "ActorsMovie",
                newName: "IX_ActorsMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorsMovie",
                newName: "IX_ActorsMovie_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsMovie",
                table: "ActorsMovie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovie_Actors_ActorId",
                table: "ActorsMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovie_Movies_MovieId",
                table: "ActorsMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
