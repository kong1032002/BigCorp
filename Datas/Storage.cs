using System.ComponentModel.DataAnnotations;

namespace BigCorp.Datas
{
    public class Storage
    {
        private const int Factory = 0;
        private const int Service = 1;
        private const int Agent = 2;
        [Key] public int Id { get; set; }
        [Required] public string Type { get; set; }
        public string Address { get; set; }
    }
}
