using AutoMapper;
using CrimeScene.Datas.Models;
using CrimeScene.DTO;

namespace SceneCrimeApi.Profiles
{
    public class CrimeSQLProfile : Profile
    {
        public CrimeSQLProfile()
        {
            CreateMap<CreateCrimeSQLDTO, CrimeEventSQL>();
            CreateMap<CrimeEventSQL, CreateCrimeSQLDTO>();
        }
    }
}
