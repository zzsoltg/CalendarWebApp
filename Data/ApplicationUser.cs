using Microsoft.AspNetCore.Identity;

namespace CalendarWebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int BaseFreeDays => 20;

        public int AgeBasedExtraFreeDays
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age)) age--;
                if (age >= 45) return 10;
                if (age >= 43) return 9;
                if (age >= 41) return 8;
                if (age >= 39) return 7;
                if (age >= 37) return 6;
                if (age >= 35) return 5;
                if (age >= 33) return 4;
                if (age >= 31) return 3;
                if (age >= 28) return 2;
                if (age >= 25) return 1;
                return 0;
            }
        }

        public int TotalFreeDays => BaseFreeDays + AgeBasedExtraFreeDays;
    }

}
