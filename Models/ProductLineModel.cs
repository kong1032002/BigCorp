using BigCorp.Datas;
using System.ComponentModel.DataAnnotations;

namespace BigCorp.Models
{
    public class ProductLineModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
