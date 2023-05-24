using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;

namespace SuperShop.Models.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);  
        
        Task<IdentityResult> AddUserAsync(User user, string password);   

    }
}
