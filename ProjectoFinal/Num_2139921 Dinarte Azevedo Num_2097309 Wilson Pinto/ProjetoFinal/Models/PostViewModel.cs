namespace ProjetoFinal.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string? Image { get; set; }
        public DateTime Date { get; set; }
        public int LikeCount { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public ICollection<Post> UserPosts { get; set; }

    }
}
