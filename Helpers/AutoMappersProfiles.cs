using AppAPI.DTOs;
using AppAPI.Entities;
using AppAPI.Extension;
using AutoMapper;

namespace AppAPI.Helpers
{
    public class AutoMappersProfiles:Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<AppUser,MemberDto>().
                ForMember(d=>d.Age,o=>o.MapFrom(s=>s.DateOfBirth.CalculateAge()))
                .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url))
                .ReverseMap();
            CreateMap<Photo,PhotoDto>().ReverseMap();

        }
    }
}
