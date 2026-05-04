using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos.GenreDto;

public record class CreateGenreDto
(
    [Required][StringLength(100)] string Name
);