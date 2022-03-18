using System.ComponentModel.DataAnnotations; // [Key], [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Table], [Column]

namespace WestwindSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category Name is required")]
        [StringLength(15, ErrorMessage = "Category Name must be 15 or less characters")]

        public string CategoryName { get; set; } = null!;

        //[Column(TypeName = "ntext")]
        public string? Description { get; set; }

    }
}
