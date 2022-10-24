using System.ComponentModel.DataAnnotations;

namespace CrimeScene.Datas.Models
{


    public class LawEnforcement
    {
        [Key]   
        public Guid Id { get; set; }
        public Rank? RankEnforcement { get; set; }

        public List<CrimeEvent>? Events { get; set; }

    }
}
