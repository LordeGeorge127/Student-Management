using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //Student student = _context.students.Include(a => a.Address).FirstOrDefault(c=> c.Id == id);
            //var students = await _studentRepository.GetAll();

            IEnumerable<Student> students = await _studentRepository.GetAll();
            return View(students);

        }
        public async Task<IActionResult> Detail(int id)
        {
            Student student=await _studentRepository.GetByIdAsync(id);
            return View(student);
        }
        public IActionResult Create()
        {
            var createstudentViewModel = new CreateStudentViewModel();
            
            return View(createstudentViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateStudentViewModel createStudentViewModel  )
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Firstname = createStudentViewModel.Firstname,
                    Lastname = createStudentViewModel.Lastname,
                    DateOfBirth = createStudentViewModel.DateOfBirth,
                    Phone = createStudentViewModel.Phone,
                    Email = createStudentViewModel.Email,
                    Gender = createStudentViewModel.Gender,
                    Address = new Address
                    {
                        City = createStudentViewModel.Address.City,
                        County = createStudentViewModel.Address.County,
                        Country = createStudentViewModel.Address.County,
                    },
                    
                  
                };


                _studentRepository.Add(student);
                return RedirectToAction("Index");
            }
            return View(createStudentViewModel);
        }
        public async Task<IActionResult> EditStudentDetails(int id) 
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return View("Error");
            }
            var studentVM = new EditStudentViewModel
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                Email = student.Email,
                Gender = student.Gender,
                AddressId = student.AddressId,
                Address = student.Address

            };
            return View(studentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditStudentDetails(int id, EditStudentViewModel editStudentViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to Edit");
                return View("EditStudentDetails", editStudentViewModel);
            }
            var userStudent= await _studentRepository.GetByIdAsyncNoTracking(id);
            if (userStudent != null)
            {
                var student = new Student
                {
                    Id = id,
                    Firstname = editStudentViewModel.Firstname,
                    Lastname = editStudentViewModel.Lastname,
                    DateOfBirth = editStudentViewModel.DateOfBirth,
                    Phone = editStudentViewModel.Phone,
                    Email = editStudentViewModel.Email,
                    Gender = editStudentViewModel.Gender,
                    AddressId = editStudentViewModel.AddressId,
                    Address = editStudentViewModel.Address,

                };
                _studentRepository.Update(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View(editStudentViewModel);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var studentDetails = await _studentRepository.GetByIdAsync(id);
            if (studentDetails == null)
            {
                return View("Error");
            }
            return View(studentDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentDetails = await _studentRepository.GetByIdAsync(id);
            if (studentDetails == null) return View("Error");
            _studentRepository.Delete(studentDetails);
            return RedirectToAction("Index");
        }


    }

}
