using System.ComponentModel.DataAnnotations;

namespace Cheffie.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int CookId { get; set; }
        [Display(Name="Заглавие")]
        public string? Title { get; set; }
        [Display(Name = "Съдържание")]
        public string? Content { get; set; }
        [Display(Name = "Дата на публикуване")]
        public DateTime? PostDate { get; set;} = DateTime.Now;
        [Display(Name = "Автор")]
        
        public Cook? Cook { get; set; }
        public ICollection<PostComment>? PostsComments { get; set;}
    }
}
