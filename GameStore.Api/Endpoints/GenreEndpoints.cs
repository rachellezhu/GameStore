using GameStore.Api.Data;
using GameStore.Api.Dtos.GenreDto;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    const string GetGenreByIdRouteName = "GetGenreById";

    public static void MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Genres.AsNoTracking().ToListAsync());

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            var genre = await dbContext.Genres.FindAsync(id);

            return genre is null ? Results.NotFound() : Results.Ok(genre);
        }).WithName(GetGenreByIdRouteName);

        group.MapPost("/", async (CreateGenreDto newGenre, GameStoreContext dbContext) =>
        {
            Genre genre = new()
            {
                Name = newGenre.Name
            };

            dbContext.Genres.Add(genre);
            await dbContext.SaveChangesAsync();

            GenreDetailsDto genreDto = new(
                genre.Id,
                genre.Name
            );

            return Results.CreatedAtRoute(GetGenreByIdRouteName, new { id = genre.Id }, genreDto);
        });

        group.MapPut("/{id}", async (int id, UpdateGenreDto updatedGenre, GameStoreContext dbContext) =>
        {
            var existingGenre = await dbContext.Genres.FindAsync(id);

            if (existingGenre is null)
            {
                return Results.NotFound();
            }

            existingGenre.Name = updatedGenre.Name;
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Genres.Where(genre => genre.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}
