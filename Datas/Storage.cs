using Microsoft.Build.Framework;

namespace BigCorp.Datas
{
    public class Storage
    {
        [Required]
        public ApplicationUser user { get; set; }
        [Required]
        public Product product { get; set; }
    }
}
