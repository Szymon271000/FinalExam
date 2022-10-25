using System.ComponentModel.DataAnnotations;

namespace CrimeScene.DTO
{
    public class CreateCrimeSQLDTO
    {
        [Required]
        public string EventId { get; set; }

        public string? Description { get; set; }
    }
}
