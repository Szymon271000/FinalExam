using System.ComponentModel.DataAnnotations;

namespace CrimeScene.DTO
{
    public class CreatePolicemanDTO
    {
        [Required]
        public Guid Id { get; set; }

    }
}
