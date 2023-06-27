using SMS.Models;

namespace SMS.ViewModels
{
    public class CreateParentViewModel
    {
        public int Id { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        public Address Address { get; set; }
        public string FathersPhone { get; set; }
        public string MothersPhone { get; set; }
        public string Email { get; set; }
    }
}
