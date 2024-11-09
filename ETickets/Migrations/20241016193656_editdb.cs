using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class editdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actorsMovie_actors_ActorId",
                table: "actorsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_actorsMovie_movie_MovieId",
                table: "actorsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_categories_CategoryId",
                table: "movie");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_cinema_CinemaId",
                table: "movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actorsMovie",
                table: "actorsMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_actors",
                table: "actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie",
                table: "movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinema",
                table: "cinema");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "actorsMovie",
                newName: "ActorsMovie");

            migrationBuilder.RenameTable(
                name: "actors",
                newName: "Actors");

            migrationBuilder.RenameTable(
                name: "movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "cinema",
                newName: "Cinemas");

            migrationBuilder.RenameIndex(
                name: "IX_actorsMovie_MovieId",
                table: "ActorsMovie",
                newName: "IX_ActorsMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_actorsMovie_ActorId",
                table: "ActorsMovie",
                newName: "IX_ActorsMovie_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_CinemaId",
                table: "Movies",
                newName: "IX_Movies_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_CategoryId",
                table: "Movies",
                newName: "IX_Movies_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ActorsMovie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorsMovie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ActorsId",
                table: "ActorsMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "ActorsMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsMovie",
                table: "ActorsMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovie_Actors_ActorId",
                table: "ActorsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovie_Movies_MovieId",
                table: "ActorsMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsMovie",
                table: "ActorsMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "ActorsId",
                table: "ActorsMovie");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "ActorsMovie");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "ActorsMovie",
                newName: "actorsMovie");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "actors");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movie");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "cinema");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovie_MovieId",
                table: "actorsMovie",
                newName: "IX_actorsMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovie_ActorId",
                table: "actorsMovie",
                newName: "IX_actorsMovie_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaId",
                table: "movie",
                newName: "IX_movie_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryId",
                table: "movie",
                newName: "IX_movie_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "actorsMovie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "actorsMovie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actorsMovie",
                table: "actorsMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_actors",
                table: "actors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie",
                table: "movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinema",
                table: "cinema",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_actorsMovie_actors_ActorId",
                table: "actorsMovie",
                column: "ActorId",
                principalTable: "actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_actorsMovie_movie_MovieId",
                table: "actorsMovie",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_categories_CategoryId",
                table: "movie",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_cinema_CinemaId",
                table: "movie",
                column: "CinemaId",
                principalTable: "cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
