using System.Security.Policy;

namespace ProjetoFinal.Models
{
    public static class SocialNetworkDBInitializer
    {
        public static void InsertData(SocialNetworkDBContext context)
        {
            var user = new User
            {
                UserName = "Admin",
                FirstName = "Bob",
                LastName = "Pots",
                Email = "bobpots@gmail.com",
                Password = "qwerty",
                Country = "Portugal",
                //Gender = "male",
                PicturePath = ""
            };
            context.Users.Add(user);
            var dbUser = context.Users.Add(user);


            context.Posts.Add(new Post
            {
                //Id = 1,
                Message = "Hello World",
                Image = "",
                Date = DateTime.Now,
                LikeCount = 0,
                Comment = "",
                User = user
                //UserId = dbUser.Entity.Id
            });

            context.SaveChanges();
        }
    }
}
