using AutoMapper;
using PhotoEcosystem.ImageService.Dtos;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Profiles
{
    /// <summary>
    /// Класс маппинга фотографии
    /// </summary>
    public class PhotoProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PhotoProfile()
        {
            CreateMap<PhotoCreateDto, Photo>();
            CreateMap<Photo, PhotoReadDto>()
                .ForMember(dst => dst.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dst => dst.IsPrivate, opts => opts.Ignore())
                .ForMember(dst => dst.LikesCount, opts => opts.Ignore());
        }
    }
}
