using System.Data.Entity;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public class UserService : IUserService
    {
        private readonly SocialNetworkDBContext context;


        public UserService(SocialNetworkDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var users = context.Users
                .Include(u => u.UserName);
            return users;
        }

        public User? Get(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            return user;
        }

        public User? GetById(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public User GetByUserName(string userName)
        {
            var user = context.Users
                .Include(u => u.Id)
                .SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        public User Create(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }

        public void DeleteById(int id)
        {
            var user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void Update(int id, User user)
        {
            var userUp = context.Users.Find(id);

            if (userUp is null)
            {
                throw new NullReferenceException("User does not exist");
            }
            else
            {
                userUp.UserName = user.UserName;
                userUp.FirstName = user.FirstName;
                userUp.LastName = user.LastName;
                userUp.Email = user.Email;
                userUp.PicturePath = user.PicturePath;
                userUp.Password = user.Password;
                userUp.Country = user.Country;
              //  userUp.Gender = user.Gender;

                context.SaveChanges();
            }
        }

        public User? FindByName(string userName)
        {
            return context.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}
