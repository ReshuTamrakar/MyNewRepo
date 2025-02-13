using System.ComponentModel.DataAnnotations;

namespace LoginApp.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; } = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int IsActive { get; set; } = 1;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
