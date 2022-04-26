using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDbCrud_Sample.Business.Abstract;
using MongoDbCrud_Sample.Entities.Concrete;
using MongoDbCrud_Sample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbCrud_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StudentList()
        {
            return View(_studentService.GetAllStudents());
        }

        [HttpGet]
        public IActionResult DetailByName(string name)
        {
            return View(_studentService.GetStudentByName(name));
        }

        [HttpGet]
        public IActionResult DetailById(string id)
        {
            return View(_studentService.GetStudentById(id));
        }
        public IActionResult Create()
        {
            return View();
        }       

        [HttpPost]
        public IActionResult CreatePost(Student entity)
        {
            _studentService.Create(entity);
            return RedirectToAction(nameof(StudentList));
        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            var editStudent = _studentService.GetStudentByName(name);
            return View(editStudent);
        }

        [HttpPost]
        public IActionResult EditPost(string id, Student entity)
        {
            _studentService.Update(id, entity);
            return RedirectToAction(nameof(StudentList));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            var deleteStudent = _studentService.GetStudentByName(name);
            return View(deleteStudent);
        }

        [HttpPost]
        public IActionResult DeletePost(string name)
        {
            _studentService.Delete(name);
            return RedirectToAction(nameof(StudentList));
        }
    }
}
