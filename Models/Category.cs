using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        [Display(Name = "Parent Category")]
        public virtual Category ParentCategory { get; set; }
    }
}