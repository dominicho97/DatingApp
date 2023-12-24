using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, OptionsBuilderConfigurationExtensions => OptionsBuilderConfigurationExtensions.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
        }



    }
}