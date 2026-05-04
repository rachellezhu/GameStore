using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos.GameDto;

public record class UpdateGameDto
(
    [Required][StringLength(100)] string Name,
    [Range(1, 50)] int GenreId,
    [Range(1, 10000)] decimal Price,
    DateOnly ReleaseDate
);
