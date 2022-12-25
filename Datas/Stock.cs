using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int id { get; set; }
        public int exp { get; set; }
        public int factory { get; set; }
        public DateTime mfg { get; set; }
        public int productLine { get; set; }
    }
}
