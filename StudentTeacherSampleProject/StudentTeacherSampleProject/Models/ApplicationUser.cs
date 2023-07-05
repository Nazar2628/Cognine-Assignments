using Microsoft.AspNetCore.Identity;

namespace StudentTeacherSampleProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
    }
}
