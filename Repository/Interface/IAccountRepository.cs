using BigCorp.Models;
using Microsoft.AspNetCore.Identity;

namespace BigCorp.Repository.Interface
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
