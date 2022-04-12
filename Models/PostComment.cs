namespace Cheffie.Models
{
    public class PostComment
    {
        public int PostCommentId { get; set; }
        public int PostId { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Post? Posts { get; set; }
        public int Rating { get; set; }

     }
}
