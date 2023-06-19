using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Interface;
using SMS.Models;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IStudentRepository _studentRepository;

        public StudentsController(DataContext context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }
        

        public async Task<IActionResult> Index()
        {
            var students = _context.students.ToList();
            return View();
        }
        public IActionResult Create()
        {
            
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student  )
        {
            if (ModelState.IsValid)
            {
                return View (student);
            }
            _studentRepository.Add(student);
            return RedirectToAction("Index");
        }
    }

}
