using CrimeScene.Datas.Models;

namespace WebApp.Services.Policemen
{
    public interface IPolicemenManager
    {
        public Task<List<LawEnforcement>> FetchAllPolicemen();

    }
}
