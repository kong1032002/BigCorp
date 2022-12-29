using BigCorp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Products")]
    public class Product : ProductModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductLineId")] public virtual ProductLine? ProductLine { get; set; } = new ProductLine();
    }
}
