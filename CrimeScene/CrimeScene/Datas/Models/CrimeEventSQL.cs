using System.ComponentModel.DataAnnotations;

namespace CrimeScene.Datas.Models
{
    public class CrimeEventSQL
    {
        [Key]
        public string EventId { get; set; }

        public string? Description { get; set; }
    }
}
