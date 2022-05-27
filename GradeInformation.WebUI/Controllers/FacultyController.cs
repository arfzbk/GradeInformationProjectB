using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeInformation.Business.Abstract;
using GradeInformation.Business.Concrete;
using GradeInformation.DataAccess.Concrete.EntityFramework;
using GradeInformation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GradeInformation.WebUI.Controllers
{
    public class FacultyController : Controller
    {
        private IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }
        public IActionResult Index()
        {
            List<Faculty> values = _facultyService.GetAll();
            return View(values);
        }
    }
}