using SMS.Data.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class parents
    {
        [Key]
        public int Id { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string FathersPhone { get; set; }
        public string MothersPhone { get; set; }
        public string Email { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public Gender Gender { get; set; }
      
        public ICollection<StudentParent> studentParents { get; set; }
    }
}
