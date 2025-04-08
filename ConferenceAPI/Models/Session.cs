using System.ComponentModel.DataAnnotations;

namespace ConferenceAPI.Models
{
    public class Session
    {
        [Key]

        public int SessionID { get; set; }

        [Required]
        [StringLength(100)] // Maximum 100 characrters for the SessionTitle
        public string SessionTitle { get; set; }
        [Required]
        public DateTime SessionDateTime { get; set; }
        [Required]
        [StringLength(50)] // Maximum 50 characrters for the speaker
        public string Speaker { get; set; }

        //Nav property for related Registrations
        public ICollection<Registration> Registrations { get; set; }
    }
}