using Microsoft.AspNetCore.Identity;

namespace BigCorp.Datas
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        //public string lastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
