namespace BigCorp.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int productLine { get; set; }
        public int stock { get; set; }
        public int status { get; set; }
        public int warrantyTime { get; set; }
        public int owner { get; set; }
    }
}
