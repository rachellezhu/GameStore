using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos.GenreDto;

public record class UpdateGenreDto
(
    [Required][StringLength(100)] string Name
);