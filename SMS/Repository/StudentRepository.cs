using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Interface;
using SMS.Models;

namespace SMS.Repository
{
    
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Student student)
        {
           _context.Add(student);
            return Save();
        }

        public bool Delete(Student student)
        {
            _context.Remove(student);
            return Save();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            //return await _context.students.ToListAsync();
            return await _context.students.Include(a => a.Address).Include(p => p.studentParents).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.students.Include(s => s.Address).FirstOrDefaultAsync(s=> s.Id == id);
        }

        public async Task<Student> GetByIdAsyncNoTracking(int id)
        {
            return await _context.students.Include(s => s.Address).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        //public async Task<IEnumerable<Student>> GetStudentByCity(string city)
        //{
        //    return await _context.students.Where(c => c.Address.City.Contains(city)).ToListAsync();
        //}

        public ICollection<Student> GetStudentByParent(int parentId)
        {
            return _context.studentParents.Where(p => p.ParentId == parentId).Select(s => s.student).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved > 0 ? true : false;
        }

        public bool Update(Student student)
        {
           _context.Update(student);
            return Save();
        }
    }
}
