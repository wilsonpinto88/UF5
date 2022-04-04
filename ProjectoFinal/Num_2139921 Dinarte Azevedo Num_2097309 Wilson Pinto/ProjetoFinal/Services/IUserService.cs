using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public interface IUserService
    {
        public abstract IEnumerable<User> GetAll();
        public abstract User? Get(string userName, string password);
        public abstract User? GetById(int id);
        public abstract User? GetByUserName(string userName);
        public abstract User Create(User newUser);
        public abstract void DeleteById(int id);
        public abstract void Update(int id, User user);
        public User? FindByName(string userName);
    }
}
