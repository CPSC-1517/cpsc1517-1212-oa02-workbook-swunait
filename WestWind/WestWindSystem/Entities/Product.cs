
using System.ComponentModel.DataAnnotations; // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // for [Table]

namespace WestWindSystem.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]    // sql serer data type is money 
        public decimal UnitPrice { get; set; }

        public int UnitsOnOrder { get;set; }

        public bool Discontinued { get; set; }

    }
}
