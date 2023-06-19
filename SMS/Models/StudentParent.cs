namespace SMS.Models
{
    public class StudentParent
    {
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        public Student student { get; set; }
        public parents parents { get; set; }
    }
}
