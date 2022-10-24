using SceneCrimeApi.Datas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeScene.Datas.Models
{


    public class LawEnforcement
    {
        [Key]   
        public Guid Id { get; set; }
        public Rank? RankEnforcement { get; set; }
        public List<CrimeEvent>? crimeEvents { get; set; }
    }
}
