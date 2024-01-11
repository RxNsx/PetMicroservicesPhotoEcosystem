using AutoMapper;
using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.LastTimeOnline, opts => opts.MapFrom(src => DateTime.UtcNow));

            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status))
                .ForMember(dest => dest.LastTimeOnline, opts => opts.MapFrom(src => src.LastTimeOnline));

            CreateMap<UserReadDto, User>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status))
                .ForMember(dest => dest.LastTimeOnline, opts => opts.MapFrom(src => src.LastTimeOnline));

        }
    }
}
