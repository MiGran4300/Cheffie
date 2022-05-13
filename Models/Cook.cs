using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cheffie.Models
{
    public class Cook
    {
       
       public int CookId { get; set; }
        public string? OwnerID { get; set; }
        [Display(Name ="Име")]
        public string? Name { get; set; }
       public string? Email { get; set; }
        [Display(Name = "Умения")]
        public string? Skill { get; set; }

        [Display(Name = "Дата на раждане")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [DisplayName("File Name")]
        public string? FilePath { get; set; }
        [NotMapped]
        [DisplayName("Снимка/Аватар")]
        public IFormFile? File { get; set; }

        public ICollection<Post>? posts { get; set; }

    }
}
