using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Interface;
using SMS.Models;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class ParentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IParentRepository _parentRepository;

        public ParentsController(DataContext context, IParentRepository parentRepository)
        {
            _context = context;
            _parentRepository = parentRepository;
        }


        public async Task<IActionResult> Index()
        {
            //Student student = _context.students.Include(a => a.Address).FirstOrDefault(c=> c.Id == id);
            //var students = await _studentRepository.GetAll();

            IEnumerable<parents> parents1 = await _parentRepository.GetAll();
            return View(parents1);

        }
        public async Task<IActionResult> Detail(int id)
        {
            parents parent = await _parentRepository.GetByIdAsync(id);
            return View(parent);
        }
        public IActionResult Create()
        {
            var createparentViewModel = new CreateParentViewModel();

            return View(createparentViewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateParentViewModel createParentViewModel )
        {
            if (ModelState.IsValid)
            {
                var parent1 = new parents
                {
                    FathersName = createParentViewModel.FathersName,
                    MothersName = createParentViewModel.MothersName,
                    FathersPhone = createParentViewModel.FathersPhone,
                   MothersPhone = createParentViewModel.MothersPhone,
                    Email = createParentViewModel.Email,
                    
                    Address = new Address
                    {
                        City = createParentViewModel.Address.City,
                        County = createParentViewModel.Address.County,
                        Country = createParentViewModel.Address.County,
                    }
                };


                _parentRepository.Add(parent1);
                return RedirectToAction("Index");
            }
            return View(createParentViewModel);
        }
        public async Task<IActionResult> EditparentDetails(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            if (parent == null)
            {
                return View("Error");
            }
            var parentVM = new EditParentViewModel
            {
                FathersName = parent.FathersName,
                MothersName = parent.MothersName,
               FathersPhone = parent.FathersPhone,
               MothersPhone = parent.MothersPhone,     
                Email = parent.Email,
                AddressId = parent.AddressId,
                Address = parent.Address

            };
            return View(parentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditParentDetails(int id, EditParentViewModel editParentViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to Edit");
                return View("EditParentDetails", editParentViewModel);
            }
            var userParent = await _parentRepository.GetByIdAsyncNoTracking(id);
            if (userParent != null)
            {
                var parent = new parents
                {
                    Id = id,
                    FathersName =editParentViewModel.FathersName,
                    MothersName = editParentViewModel.MothersName,
                    FathersPhone = editParentViewModel.FathersPhone,
                    MothersPhone = editParentViewModel.MothersPhone,
                    Email = editParentViewModel.Email,
                    AddressId = editParentViewModel.AddressId,
                    Address = editParentViewModel.Address,

                };
                _parentRepository.Update(parent);
                return RedirectToAction("Index");
            }
            else
            {
                return View(editParentViewModel);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var parentsDetails = await _parentRepository.GetByIdAsync(id);
            if (parentsDetails == null)
            {
                return View("Error");
            }
            return View(parentsDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parentDetails = await _parentRepository.GetByIdAsync(id);
            if (parentDetails == null) return View("Error");
            _parentRepository.Delete(parentDetails);
            return RedirectToAction("Index");
        }


    }

}
