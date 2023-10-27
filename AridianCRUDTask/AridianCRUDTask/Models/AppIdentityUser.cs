using Microsoft.AspNetCore.Identity;

namespace AridianCRUDTask.Models
{
    public class AppIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
