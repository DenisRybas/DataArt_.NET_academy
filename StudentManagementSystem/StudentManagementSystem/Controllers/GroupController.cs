using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DbContexts;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    public class GroupController : Controller
    {
        private readonly StudentGroupService _service;

        public GroupController(GroupContext context)
        {
            _service = new StudentGroupService(context);
        }

        public IActionResult Index()
        {
            return View(_service.AllGroups());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            ViewBag.Groups = _service.AllGroups();
            return id == 0 ? View(new Student()) : View(_service.FindStudent(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> AddOrEdit([Bind("StudentId,GroupId,Name,Surname,Patronymic")]
            Student student)
        {
            ViewBag.Groups = _service.AllGroups();
            if (!ModelState.IsValid) return Task.FromResult<IActionResult>(View(student));
            if (student.StudentId == 0)
                _service.AddStudentToDb(student);
            else
                _service.UpdateStudent(student);
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
        }

        public IActionResult Remove(int id)
        {
            _service.RemoveStudentFromDb(_service.FindStudent(id));
            return RedirectToAction(nameof(Index));
        }
    }
}