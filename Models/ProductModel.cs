using BigCorp.Datas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Models
{
    public class ProductModel
    {
        public string Status { get; set; } = "Moi";
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ?ProductLineId { get; set; }
        public DateTime Exp { get; set; } = DateTime.Now.AddMonths(24);
        public DateTime Mfg { get; set; } = DateTime.Now;
    }
}
