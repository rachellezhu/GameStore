namespace GameStore.Api.Dtos.GenreDto;

// A DTO is a contract between the client and server since it represents
// a shared agreement about how data will be transfered and used.

public record class GenreDetailsDto
(
    int Id,
    string Name
);
