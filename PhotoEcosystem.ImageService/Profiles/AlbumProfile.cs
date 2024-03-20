using AutoMapper;
using PhotoEcosystem.ImageService.Dtos.Albums;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Profiles
{
    /// <summary>
    /// Профайл маппера для альбома
    /// </summary>
    public class AlbumProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AlbumProfile()
        {
            CreateMap<Album, AlbumReadDto>();
            CreateMap<AlbumUpdateDto, Album>();
            CreateMap<AlbumCreateDto, Album>();
        }
    }
}
