using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using E_commerce.Bl;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsApiController : ControllerBase
    {
        IItemService ItemService;
        public ItemsApiController(IItemService itemService)
        {
            ItemService = itemService;
        }
        // GET: api/ItemsApi
        [HttpGet]
        public IEnumerable<VwItemCategories> Get()
        {
            var items = ItemService.GetAllItems();
            return items;
        }

        // GET: api/ItemsApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItemsApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ItemsApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
