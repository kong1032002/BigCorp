using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Stock")]
    public class Stock
    {
        [Key] public int Id { get; set; }
        [Required] public int StorageId { get; set; }
        [Required] public int ProductLineId { get; set; } = 0;
        [ForeignKey("StorageId")] public AppUser Storage { get; set; }
        [ForeignKey("ProductLineId")] public ProductLine ProductLine { get; set; }
        public DateTime Mfg { get; set; } = DateTime.Now;
    }
}
