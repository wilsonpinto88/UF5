using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using ProjetoFinal.Services;

namespace ProjetoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config;
        private readonly IJWTService tokenService;
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly IWebHostEnvironment hostEnvironment;
        public bool isUserLoggedin = false;

        public HomeController(IConfiguration config, IJWTService tokenService, IUserService userService, IPostService postService, IWebHostEnvironment hostEnvironment)
        {
            this.config = config;
            this.tokenService = tokenService;
            this.userService = userService;
            this.postService = postService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult SignUp()
        {
            //string token = HttpContext.Session.GetString("Token");
            //var id = tokenService.GetJWTTokenClaim(token);

            //ViewBag.Id = id;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var userExists = userService.GetByUserName(user.UserName);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "User already exists!");

                var newUser = userService.Create(user);
                if (newUser != null)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Error");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(User userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return RedirectToAction("Error");
            }
            
            var user = userService.Get(userModel.UserName, userModel.Password);

            var validUser = new UserViewModel { UserName = user.UserName, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Country = user.Country };

            if (validUser != null)
            {
                string generatedToken = tokenService.GenerateToken(
                    config["Jwt:Key"].ToString(),
                    config["Jwt:Issuer"].ToString(),
                    config["Jwt:Audience"].ToString(),
                    validUser);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(validUser));
                    isUserLoggedin = true;
                    return Redirect("feed");
                }
                else
                {
                    return (RedirectToAction("Error"));
                }
            }
            else
            {
                return (RedirectToAction("Error"));
            }
        }

        public async Task<IActionResult> LogoutUser()
        {
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Profile(UserViewModel user)
        //{
        //    string token = HttpContext.Session.GetString("Token");

        //    if (token == null)
        //    {
        //        return (RedirectToAction("Index"));
        //    }

        //    if (!tokenService.IsTokenValid(
        //            config["Jwt:Key"].ToString(),
        //            config["Jwt:Issuer"].ToString(),
        //            config["Jwt:Audience"].ToString(),
        //            token))
        //    {
        //        return (RedirectToAction("Index"));
        //    }

        //    ViewBag.Token = token;
        //    return View(user);
        //}

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(HttpContext.Session.GetString("User"));
            Post newPost = new Post
            {
                UserId = user.Id,
                Date = DateTime.Now,
                Image = post.Image,
                LikeCount = post.LikeCount,
                Message = post.Message
            };

                var addPost = postService.Create(newPost);

                if (addPost != null)
                {
                    return Redirect("/feed");
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }
            //if (ModelState.IsValid)
            //{
            //}
            return RedirectToAction(nameof(Error));
        }

        //[HttpPost]
        //public async Task<IActionResult> Update(Post post, int id)
        //{
        //    var updatedPost = postService.Update(post, id);
        //    if (updatedPost is not null)
        //    {
        //        return Redirect("feed");
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Error));
        //    }
        //}

        //public IActionResult Delete(int id)
        //{
        //    var post = postService.GetById(id);
        //    if (post is not null)
        //    {
        //        postService.DeleteById(id);
        //        return Redirect("feed");
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Error));
        //    }

        //}

        //[HttpPost("FileUpload")]
        //public IActionResult Index(IFormFile file)
        //{
        //    string path = Path.Combine(this.hostEnvironment.WebRootPath, "images");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    string fileName = Path.GetFileName(file.FileName);
        //    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //        return RedirectToAction("SignUp", new User { PicturePath = file.FileName });
        //    }

        //    return RedirectToAction("Error");
        //}

        // Comment Posts

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Post()
        {
            return View();
        }

        /*
        public IActionResult Logout()
        {
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Profile()
        {
            UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(HttpContext.Session.GetString("User"));

            return View(user);
        }
    }
}