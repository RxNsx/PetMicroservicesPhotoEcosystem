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
        }
    }
}
