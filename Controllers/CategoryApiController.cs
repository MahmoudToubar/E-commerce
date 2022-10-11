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
    public class CategoryApiController : ControllerBase
    {
        ICategoryService CategoryService;
        public CategoryApiController(ICategoryService category)
        {
            CategoryService = category;
        }
        // GET: api/CategoryApi
        [HttpGet]
        public IEnumerable<TbCategories> Get()
        {
            return CategoryService.GetAll();
        }

        // GET: api/CategoryApi/5
        [HttpGet("{id}", Name = "GetCategories")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CategoryApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CategoryApi/5
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

