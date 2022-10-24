using System.ComponentModel.DataAnnotations;

namespace SceneCrimeApi.DTOs
{
    public class CreateCrimeEventDTO
    {
        [Required]
        public string? type { get; set; }

        public string? shortDescription { get; set; }

        [Required]
        public string? city { get; set; }
        [Required]
        public string? address { get; set; }
        public float? postalCode { get; set; }
    }
}
