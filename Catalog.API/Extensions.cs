using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API
{
    public static class Extensions
    {
        public static ItemDTO AsDTO(this Item item)
            => new ItemDTO
            {
                Name = item.Name,
                Price = item.Price,
                Created = item.Created,
                Id = item.Id
            };
        public static Item CreateItemFromDTO(this CreateItemDTO dto)
            => new Item
            {
                Name = dto.Name,
                Price = dto.Price,
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.UtcNow,
            };
    }
}
