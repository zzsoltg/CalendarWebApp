using Microsoft.AspNetCore.Identity;

namespace CalendarWebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateOnly DateOfBirth { get; set; }
    }

}
