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
    public class SliderApiController : ControllerBase
    {
        ISliderService SliderService;
        
        public SliderApiController(ISliderService sliderService)
        {
            SliderService = sliderService;
        }
        // GET: api/SliderApi
        [HttpGet]
        public IEnumerable<VwSliderCategories> Get()
        {
            var slider = SliderService.GetAllSlider();
            return slider;
        }

        // GET api/SliderApi/5
        [HttpGet("{id}", Name = "GetSlider")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/SliderApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/SliderApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/SliderApi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
