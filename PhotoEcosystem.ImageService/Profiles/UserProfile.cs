using AutoMapper;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.SyncDataClient.Models;

namespace PhotoEcosystem.ImageService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<HttpUser, User>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.LastTimeOnline, opt => opt.MapFrom(src => src.LastTimeOnline))
                .ForMember(dest => dest.Albums, opt => opt.Ignore());
        }
    }
}
