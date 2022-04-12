using Cheffie.Models;

namespace Cheffie.ViewModels
{
    public class PostCommentViewModel
    {
        public string? Title { get; set; }
        public List<PostComment>? ListOfComment { get; set; }
        public string? CommentText { get; set; }
        public int PostId { get; set; }
        public int Rating { get; set; }
    }
}
