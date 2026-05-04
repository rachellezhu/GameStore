namespace GameStore.Api.Dtos.GameDto;

// A DTO is a contract between the client and server since it represents
// a shared agreement about how data will be transfered and used.

public record class GameSummaryDto
(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
