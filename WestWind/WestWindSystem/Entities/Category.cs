using System.ComponentModel.DataAnnotations;    // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // for [Table]


namespace WestWindSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; } 
        //public byte[]? Picture { get; set; }

        //public string? PictureMimeType { get; set; }
    }
}
