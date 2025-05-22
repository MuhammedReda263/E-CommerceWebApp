using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (10 ,ErrorMessage = "Max Length of characters mustn't be more than 10 characters")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Range (1,100 ,ErrorMessage = "Display order must be between 1 to 100")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
