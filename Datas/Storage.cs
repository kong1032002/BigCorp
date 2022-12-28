using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigCorp.Datas
{
    [Table("Storage")]
    public class Storage
    {
        [Key]
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public Product product { get; set; }
    }
}
