namespace VisitArrangement.API.Model.DTO
{
    using VisitArrangement.Domain.Entities;

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public string? Token { get; set; }

        public User User { get; set; }
    }
}
