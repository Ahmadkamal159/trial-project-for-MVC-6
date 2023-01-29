using Microsoft.AspNetCore.Identity;

namespace trial_project_for_MVC_Core.Models
{
    public class AppUser : IdentityUser
    {
        public byte[]? ProfilePicture { get; set;}


    }
}
