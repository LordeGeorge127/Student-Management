using SMS.Models;

namespace SMS.Interface
{
    public interface IParentRepository
    {
        Task<IEnumerable<parents>> GetAll();
        Task<parents> GetByIdAsync(int id);

        Task<parents> GetByIdAsyncNoTracking(int id);
        //Task<IEnumerable<Student>> GetStudentByCity(string city);
        //Task<IEnumerable<parents>> GetParentByStudent(int studentId);

        bool Add(parents parents1);
        bool Update(parents parents1 );
        bool Delete(parents parents1);
        bool Save();
    }
}
