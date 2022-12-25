using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public int productLine { get; set; }
        public int stock { get; set; }
        public int status { get; set; }
        public int warrantyTime { get; set; }
        public int owner { get; set; }
    }
}
