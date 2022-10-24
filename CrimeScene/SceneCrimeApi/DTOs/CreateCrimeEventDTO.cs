using System.ComponentModel.DataAnnotations;

namespace SceneCrimeApi.DTOs
{
    public class CreateCrimeEventDTO
    {
        [Required]
        public string? type { get; set; }
        [Required]
        public string? shortDescription { get; set; }

        [Required]
        public string? city { get; set; }
        [Required]
        public string? address { get; set; }
        [Required]
        public float? postalCode { get; set; }
    }
}
