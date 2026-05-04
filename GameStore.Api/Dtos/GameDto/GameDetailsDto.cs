namespace GameStore.Api.Dtos.GameDto;

// A DTO is a contract between the client and server since it represents
// a shared agreement about how data will be transfered and used.

public record class GameDetailsDto
(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);
