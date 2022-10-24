using System.ComponentModel.DataAnnotations;

namespace CrimeScene.Datas.Models
{
    public class CrimeEvent
    {
        [Key]
        public string EventId { get; set; }

        public string? Description { get; set; }
    }
}
