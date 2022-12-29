using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock Stock { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime Exp { get; set; }
    }
}
