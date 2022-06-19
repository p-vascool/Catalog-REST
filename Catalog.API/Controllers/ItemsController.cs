using Catalog.API.DTO;
using Catalog.API.Models;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController, Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
            => _repository = repository;

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
            => (await _repository
               .GetItemsAsync())
               .Select(item => item.AsDTO());

        [HttpGet("{id}")]
        public async Task<ItemDTO> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            return item.AsDTO();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateItemDTO itemDTO)
        {
            await _repository.CreateItemAsync(itemDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemAsync(Guid id, UpdateItemDTO updateItemDTO)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with
            {
                Name = updateItemDTO.Name,
                Price = updateItemDTO.Price
            };

            await _repository.UpdateItemAsync(updatedItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id)
        {
            await _repository.DeleteItemAsync(id);
            return Ok();
        }
    }
}
