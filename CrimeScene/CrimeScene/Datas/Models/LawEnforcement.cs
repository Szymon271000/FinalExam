using SceneCrimeApi.Datas.Models;

namespace CrimeScene.Datas.Models
{


    public class LawEnforcement
    {
        public Guid Id { get; set; }
        public Rank? RankEnforcement { get; set; }
        public List<CrimeEvent>? crimeEvents { get; set; }
    }
}
