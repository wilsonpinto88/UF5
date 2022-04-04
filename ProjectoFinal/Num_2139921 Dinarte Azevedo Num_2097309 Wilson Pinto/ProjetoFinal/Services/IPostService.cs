using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public interface IPostService
    {
        public abstract IEnumerable<Post> GetAll();
        //public abstract Post GetById(int id);
        public abstract Post Create(Post newPost);
        //public abstract void DeleteById(int id);
        //public abstract Post Update(Post post, int Id);

        //public abstract Post Download();
        //public abstract void UpdatePost(int id, int userId);
    }
}
