using Microsoft.AspNetCore.Identity;

namespace Moview.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
