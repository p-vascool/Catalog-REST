using Catalog.API.Models;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController, Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
            => _repository = repository;

        [HttpGet]
        public IEnumerable<Item> GetItems()
            => _repository.GetItems();

        [HttpGet("{id}")]
        public Item GetItem(Guid id)
            => _repository.GetItem(id);
    }
}
