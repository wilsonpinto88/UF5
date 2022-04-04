using FREQ_2097309.Models;
using FREQ_2097309.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FREQ_2097309.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService service;

        public OrderDetailsController(IOrderDetailService service)
        {
            this.service = service;
        }

        // GET: api/<OrderDetailsController>
        [HttpGet]
        public IEnumerable<OrderDetails> Get()
        {
            return service.GetAll();
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDetails order)
        {
            if (order != null)
            {
                OrderDetails newOrder = service.Create(order);
                return CreatedAtRoute("GetById", new { id = newOrder.Id }, newOrder);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = service.GetById(id);

            if (book is not null)
            {
                service.DeleteById(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            OrderDetails? order = service.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }


        // PUT api/<OrderDetailsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDetails order)
        {
            var orderToUpdate = service.GetById(id);
            if (order is not null && orderToUpdate is not null)
            {
                service.Update(id, order);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<OrderDetailsController>/5
        [HttpPut("{id}/products")]
        public IActionResult? Get(int id, List<Product> products)
        {
            return service.GetProducts()! as IActionResult;
        }

        // PATCH api/<OrderDetailsController>/5
        [HttpPatch("{id}/amount")]
        public IActionResult Patch(int id, int productId)
        {
            var orderToUpdate = service.GetById(id);
            if (orderToUpdate is not null)
            {
                service.UpdateAmount(id, productId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
