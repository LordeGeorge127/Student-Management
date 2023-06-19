using SMS.Models;

namespace SMS.Interface
{
    public interface IStudentRepository
    {
        bool Add(Student student);
        bool Update(Student student);   
        bool Delete(Student student);
        bool Save();
    }
}
