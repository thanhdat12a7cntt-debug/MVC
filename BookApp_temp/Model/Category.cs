using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApp_temp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 1000, ErrorMessage = "Display Order must be 1-1000")]
        public int DisplayOrder { get; set; }
    }
}
