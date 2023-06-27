using SMS.Models;

namespace SMS.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetByIdAsync(int id);


        Task<Student> GetByIdAsyncNoTracking(int id);
        //Task<IEnumerable<Student>> GetStudentByCity(string city);
        ICollection<Student> GetStudentByParent(int parentId);


        bool Add(Student student);
        bool Update(Student student);   
        bool Delete(Student student);
        bool Save();
    }
}
