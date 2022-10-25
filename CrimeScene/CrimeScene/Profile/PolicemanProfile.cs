using AutoMapper;
using CrimeScene.Datas.Models;
using CrimeScene.DTO;

namespace SceneCrimeApi.Profiles
{
    public class PolicemanProfile : Profile
    {
        public PolicemanProfile()
        {
            CreateMap<CreatePolicemanDTO, LawEnforcement>();
            CreateMap<LawEnforcement, CreatePolicemanDTO>();
        }
    }
}
