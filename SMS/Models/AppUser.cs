using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace SMS.Models
{
    public class AppUser
    {

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
      
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public ICollection<Student> students  { get; set; }
        public ICollection<parents> parents { get; set; }

    }
}
