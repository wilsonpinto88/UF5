using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoFinal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        // GET: api/<UserProfileController>
        [HttpGet]
        /*public UserViewModel Get()
        {
            return new UserViewModel { Id = 1, UserName = "Admin", FirstName= "Bob", LastName= "Pots", Country= "Portugal", Email= "bobpots@gmail.com" };
        }*/

        //public AcessUserProfileModel Get()
        //{
        //    return new AcessUserProfileModel { Id = 1, Name = "Admin"};
        //}

        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserProfileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
