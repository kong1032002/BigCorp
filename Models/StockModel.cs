using BigCorp.Datas;
using System.ComponentModel.DataAnnotations;

namespace BigCorp.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        [Required] public int StorageId { get; set; } = 0;
        [Required] public int ProductLineId { get; set; } = 0;
        [Required]
        public DateTime Mfg { get; set; } = DateTime.Now;
    }
}
