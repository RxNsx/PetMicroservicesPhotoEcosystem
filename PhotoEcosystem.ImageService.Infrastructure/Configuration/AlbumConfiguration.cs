using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoEcosystem.ImageService.Domain.Aggregates.Album;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;

namespace PhotoEcosystem.ImageService.Infrastructure.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<AlbumAggregate>
{
    public void Configure(EntityTypeBuilder<AlbumAggregate> builder)
    {
        builder.Property(album => album.AlbumName)
            .HasConversion(
                albumName => albumName.Name, 
                album => AlbumName.Create(album).Value)
            .HasMaxLength(50);
        builder.HasIndex(album => album.AlbumName).IsUnique();
        builder.OwnsMany(album => album.Photos);
        builder.HasKey(album => album.Id);
    }
}