using System.ComponentModel.DataAnnotations;

namespace ConferenceAPI.Models
{
    public class Attendee
    {
        [Key]

        public int AttendeeID { get; set; }

        [Required]
        [StringLength(50)] // Maximum 50 characrters for the Firstname
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)] // Maximum 50 characrters for the Lastname
        public string LastName { get; set; }
        [Required]
        [StringLength(100)] // Maximum 100 characrters for the Email
        public string Email { get; set; }

        //Nav property for related Registrations
        public ICollection<Registration> Registrations { get; set; }
    }
}
