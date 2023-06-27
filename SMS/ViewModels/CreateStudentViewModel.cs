using SMS.Data.Enum;
using SMS.Models;

namespace SMS.ViewModels
{
    public class CreateStudentViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        //public parents parents { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
       
    }
}
