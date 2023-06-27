using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Interface;
using SMS.Models;

namespace SMS.Repository
{

    public class ParentRepository : IParentRepository
    {
        private readonly DataContext _context;

        public ParentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(parents parents1)
        {
            _context.Add(parents1);
            return Save();
        }

        public bool Delete(parents parents1)
        {
            _context.Remove(parents1);
            return Save();
        }

        public async Task<IEnumerable<parents>> GetAll()
        {
            //return await _context.students.ToListAsync();
            return await _context.parents.Include(a => a.Address).ToListAsync();
        }

        public async Task<parents> GetByIdAsync(int id)
        {
            return await _context.parents.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<parents> GetByIdAsyncNoTracking(int id)
        {
            return await _context.parents.Include(s => s.Address).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        //public async Task<IEnumerable<parents>> GetParentByStudent(int studentId)
        //{
        //    return await _context.parents.
        //}

        //public Task<IEnumerable<Student>> GetStudentByCity(string city)
        //{
        //    return await _context.students.Where(c => c.Address.City.Contains(city)).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(parents parents1)
        {
            _context.Update(parents1);
            return Save();
        }
    }
}
