using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
    [Required][StringLength(100)] string Name,
    [Range(1, 50)] int GenreId,
    [Range(1, 10000)] decimal Price,
    DateOnly ReleaseDate
);