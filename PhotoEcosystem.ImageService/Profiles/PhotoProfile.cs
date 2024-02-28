using AutoMapper;
using PhotoEcosystem.ImageService.Dtos.Photos;
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
            CreateMap<Photo, PhotoReadDto>();
            CreateMap<PhotoUpdateDto, Photo>();
                //.ForMember(dst => dst.AlbumId, opt => opt.MapFrom(src => src.AlbumId ?? Guid.Empty)
        }
    }
}
