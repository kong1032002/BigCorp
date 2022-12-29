using BigCorp.Datas;
using System.ComponentModel.DataAnnotations;

namespace BigCorp.Models
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? StockId { get; set; } = 0;
        public string Status { get; set; } = "Moi";
        public string Exp { get; set; }
    }
}
