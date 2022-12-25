using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("ProductLine")]
    public class ProductLine
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int version { get; set; }

    }
}
