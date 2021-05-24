using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.StoreApi.Core.DBRepository;
using Task1.StoreApi.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task1.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.Get();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            Product product = await _productRepository.Get(id);
            if (product == null)
                return NotFound();
            return product;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            await _productRepository.Create(product);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Product product)
        {
            await _productRepository.Update(id, product);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _productRepository.Delete(id);
            return NoContent();
        }
    }
}
