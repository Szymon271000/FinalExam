using CrimeScene.Datas.Models;
using Microsoft.EntityFrameworkCore;
namespace CrimeScene.Datas.Context
{
    public class LawEnforcementContext:DbContext
    {
        public LawEnforcementContext(DbContextOptions<LawEnforcementContext> opt): base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<LawEnforcement> lawEnforcements { get; set; }
        public DbSet<Rank> ranks { get; set; }
        public DbSet<CrimeEventSQL> crimeEvents { get; set; }
    }
}
