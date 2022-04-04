using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services
{
    public class PostService : IPostService
    {
        private readonly SocialNetworkDBContext context;

        public PostService(SocialNetworkDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Post> GetAll()
        {
            var posts = context.Posts.Include(p => p.User);
            return posts;
        }

        //public Post? GetById(int id)
        //{
        //    var post = context.Posts
        //    .Include(b => b.UserId)
        //    .SingleOrDefault(b => b.Id == id);
        //    return post;
        //}


        public Post Create(Post newPost)
        {
            context.Posts.Add(newPost);
            context.SaveChanges();
            return newPost;
        }

        //public void DeleteById(int id)
        //{
        //    var postToDelete = context.Posts.Find(id);
        //    if (postToDelete is not null)
        //    {
        //        context.Posts.Remove(postToDelete);
        //        context.SaveChanges();
        //    }
        //}

        //public Post Update(Post post, int id)
        //{
        //    var postToUpdate = context.Posts.Find(id);
        //    if (postToUpdate is null)
        //    {
        //        throw new NullReferenceException("Post does not exist");
        //    }

        //    postToUpdate.Message = post.Message;
        //    postToUpdate.Image = post.Image;
        //    postToUpdate.UserId = post.UserId;
        //    postToUpdate.LikeCount = post.LikeCount;
        //    postToUpdate.Comment = post.Comment;
        //    postToUpdate.Date = post.Date;

        //    context.SaveChanges();
        //    return postToUpdate;
        //}

        /*public Post Download()
        {
            throw new NotImplementedException();
        }*/


        //public void UpdatePost(int id, int userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
