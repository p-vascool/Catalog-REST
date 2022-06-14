using System.ComponentModel.DataAnnotations;

namespace Catalog.API.DTO
{
    public record CreateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required, Range(1,100)]
        public decimal Price { get; init; }
    }
}
