using AutoMapper;
using SceneCrimeApi.Datas.Models;
using SceneCrimeApi.DTOs;

namespace SceneCrimeApi.Profiles
{
    public class CrimeEventProfile : Profile
    {
        public CrimeEventProfile()
        {
            CreateMap<CrimeEvent, CreateCrimeEventDTO>();
            CreateMap<CreateCrimeEventDTO, CrimeEvent>();
            CreateMap<CrimeEvent, ReadCrimeEventDTO>();
            CreateMap<ReadCrimeEventDTO, CrimeEvent>();
        }
    }
}
