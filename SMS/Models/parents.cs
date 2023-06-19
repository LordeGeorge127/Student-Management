namespace SMS.Models
{
    public class parents
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<StudentParent> studentParents { get; set; }
    }
}
