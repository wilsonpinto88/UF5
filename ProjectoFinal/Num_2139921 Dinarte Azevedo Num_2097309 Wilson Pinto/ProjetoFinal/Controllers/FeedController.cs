using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ProjetoFinal.Models;
using ProjetoFinal.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoFinal.Controllers
{
    public class FeedController : Controller
    {
        private readonly IPostService postService;

        public FeedController(IPostService postService)
        {
            this.postService = postService;
        }

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Post> posts;
            using (var client = new HttpClient())
            {
                var token = HttpContext.Session.GetString("Token");
                client.BaseAddress = new Uri("https://localhost:7260/api/");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(HttpContext.Session.GetString("User"));
                posts = postService.GetAll();

            }
            return View(posts);
        }
    }
}
