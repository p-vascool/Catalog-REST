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
        public IEnumerable<ItemDTO> GetItems()
            => _repository
               .GetItems()
               .Select(item => item.AsDTO());

        [HttpGet("{id}")]
        public ItemDTO GetItem(Guid id)
            => _repository.GetItem(id).AsDTO();

        [HttpPost]
        public IActionResult CreateItem(CreateItemDTO itemDTO)
        {
            _repository.CreateItem(itemDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(Guid id, UpdateItemDTO updateItemDTO)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with
            {
                Name = updateItemDTO.Name,
                Price = updateItemDTO.Price
            };

            _repository.UdpateItem(updatedItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(Guid id)
        {
            _repository.DeleteItem(id);
            return Ok();
        }
    }
}
