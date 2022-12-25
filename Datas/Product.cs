using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public ProductLine productLine { get; set; }
        [Required]
        public Stock stock { get; set; }
        public string? name { get; set; }
        public int status { get; set; }
    }
}
