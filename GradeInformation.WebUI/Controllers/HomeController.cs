using GradeInformation.Business.Abstract;
using GradeInformation.Entities.Concrete;
using GradeInformation.WebUI.Model;
using GradeInformation.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GradeInformation.WebUI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ISectorCompanyService _sectorCompanyService;
        private IStudentCompanyService _studentCompanyService;
        private IStudentService _studentService;
        private IDegreeService _degreeService;
        private ICityService _cityService;
        private IStudentCompanyToolService _studentCompanyToolService;
        private IFieldService _fieldService;
        private ICompanyService _companyService;
        private IToolService _toolService;
        public HomeController(ISectorCompanyService sectorCompanyService,
            IStudentCompanyService studentCompanyService,
            IStudentService studentService,
            IDegreeService degreeService,
            ICityService cityService,
            IStudentCompanyToolService studentCompanyToolService,
            IFieldService fieldService,
            ICompanyService companyService,
            IToolService toolService
            )
        {
            _sectorCompanyService = sectorCompanyService;
            _studentCompanyService = studentCompanyService;
            _studentService = studentService;
            _degreeService = degreeService;
            _cityService = cityService;
            _studentCompanyToolService = studentCompanyToolService;
            _fieldService = fieldService;
            _companyService = companyService;
            _toolService = toolService;
        }
        public ConcurrentDictionary<string, int> topSectors = new ConcurrentDictionary<string, int>(); 
        public ConcurrentDictionary<string, int> topFields = new ConcurrentDictionary<string, int>();
        public ConcurrentDictionary<string, int> topUsingTools = new ConcurrentDictionary<string, int>(); 
        public IActionResult Index()
        {
            //Ortalama calisma süresi
            var sectorCompanyList = _sectorCompanyService.GetAll();
            var ortalama = _studentCompanyService.AverageStudyDays();

            //ilk 5 sektor
            List<int> companyIdList =  _studentCompanyService.GetCompanyIds();
            _sectorCompanyService.SetTopSectors(ref topSectors,companyIdList);
            Dictionary<string,int> sortedTopSectors = topSectors.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //ilk 5 alan
           List<int> fieldIdList =  _studentCompanyService.GetAll().Select(x => x.FieldId).ToList();
            foreach (var item in fieldIdList)
            {
                var field = _fieldService.GetById(item);
                topFields.AddOrUpdate(field.FieldName, 1, (k, v) => v + 1);
            }
            Dictionary<string,int> sortedTopFields = topFields.OrderByDescending(x => x.Value).ToDictionary(x => x.Key,x => x.Value);

            //En çok kullanılan Toollar
            List<int> studentCompanyIdList = _studentCompanyService.GetAll().Select(x => x.StudentCompanyId).ToList();
            foreach (int studentCompanyId in studentCompanyIdList)
            {
               var studentCompanyTool = _studentCompanyToolService.GetAllByStudentCompanyId(studentCompanyId);
                foreach (var item in studentCompanyTool)
                {
                    var tool = _toolService.Get(item.ToolId);
                    topUsingTools.AddOrUpdate(tool.ToolName, 1, (k, v) => v + 1);
                }

            }
            Dictionary<string, int> sortedTopUsingTools = topUsingTools.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //Total Mezun Sayısı
            int countOfGraduate = _studentService.GetAll().Count;

            //Ortalamalların ortalaması
            var students = _studentService.GetAll();
            decimal totalGPA = 0;
            students.ForEach(s => totalGPA += s.Gpa);
            decimal averageGPA = totalGPA / countOfGraduate;


            var statisticalViewModel = new StatisticalViewModel
            {
                Ortalama = ortalama,
                Sectors = sortedTopSectors,
                Fields = sortedTopFields,
                Tools = sortedTopUsingTools,
                CountOfGraduate = countOfGraduate,
                AverageGPA = averageGPA,
                
            };

            return View(statisticalViewModel);
        }
        [HttpGet]
        public JsonResult GetSectorChartJSON()
        {
            //Ortalama calisma süresi
            var sectorCompanyList = _sectorCompanyService.GetAll();
            var ortalama = _studentCompanyService.AverageStudyDays();

            //ilk 5 sektor
            List<int> companyIdList = _studentCompanyService.GetCompanyIds();
            _sectorCompanyService.SetTopSectors(ref topSectors, companyIdList);
            Dictionary<string, int> sortedTopSectors = topSectors.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //ilk 5 alan
            List<int> fieldIdList = _studentCompanyService.GetAll().Select(x => x.FieldId).ToList();
            foreach (var item in fieldIdList)
            {
                var field = _fieldService.GetById(item);
                topFields.AddOrUpdate(field.FieldName, 1, (k, v) => v + 1);
            }
            Dictionary<string, int> sortedTopFields = topFields.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //En çok kullanılan Toollar
            List<int> studentCompanyIdList = _studentCompanyService.GetAll().Select(x => x.StudentCompanyId).ToList();
            foreach (int studentCompanyId in studentCompanyIdList)
            {
                var studentCompanyTool = _studentCompanyToolService.GetAllByStudentCompanyId(studentCompanyId);
                foreach (var item in studentCompanyTool)
                {
                    var tool = _toolService.Get(item.ToolId);
                    topUsingTools.AddOrUpdate(tool.ToolName, 1, (k, v) => v + 1);
                }

            }
            Dictionary<string, int> sortedTopUsingTools = topUsingTools.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //Total Mezun Sayısı
            int countOfGraduate = _studentService.GetAll().Count;

            //Ortalamalların ortalaması
            var students = _studentService.GetAll();
            decimal totalGPA = 0;
            students.ForEach(s => totalGPA += s.Gpa);
            decimal averageGPA = totalGPA / countOfGraduate;


            var statisticalViewModel = new StatisticalViewModel
            {
                Ortalama = ortalama,
                Sectors = sortedTopSectors,
                Fields = sortedTopFields,
                Tools = sortedTopUsingTools,
                CountOfGraduate = countOfGraduate,
                AverageGPA = averageGPA,
            };
            return Json(statisticalViewModel);
        }
        private void SetStudentId(ref int StudentId)
        {
            if (HttpContext.Session.GetObject<Student>("user")?.StudentId != null)
            {
                StudentId = HttpContext.Session.GetObject<Student>("user").StudentId;
            }
        }
        public IActionResult Index2()
        {
            int StudentId = 0;
            SetStudentId(ref StudentId);

            if (StudentId == 0)
            {
                TempData.Add("message", "Lütfen Giriş Yapınız");
                return RedirectToAction("Login", "Security");
            }
            var student = _studentService.GetByIdWithAllFields(StudentId);
            var cities = _cityService.GetAll();
            List<StudentCompanyTool> studentCompanyList = new List<StudentCompanyTool>();
            List<int> studentCompanyIds = student.StudentCompanies.Select(c => c.StudentCompanyId).ToList();
            studentCompanyList = _studentCompanyToolService.GetAllByStudentIdWithAllField(studentCompanyIds);

            List<Tool> toolList = _toolService.GetAll();

            var fields = _fieldService.GetAll();

            var companies = _companyService.GetAllWithAllFields();

            var studentStudiedViewModel = new StudentStudiedCompanyInfo
            {
                Student = student,
                Cities = cities,
                StudentCompanyToolList = studentCompanyList,
                Fields = fields,
                Companies = companies,
                ToolList = toolList
            };

            TempData["message"] =  "Öğrenci başarıyla listelendi";
            return View(studentStudiedViewModel);
        }
        [HttpPost]
        public IActionResult EditStudent(StudentStudiedCompanyInfo studentListViewModel)
        {
            //_cityService.GetCityById(studentListViewModel.CityId)
            var city = new City { CityId = studentListViewModel.CityId} ;
            var degree = _degreeService.GetDegreeByName(studentListViewModel.DegreeName + "\r\n");

            studentListViewModel.Student.CityId = studentListViewModel.CityId;
            studentListViewModel.Student.DegreeId = degree.DegreeId;
            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.Update(studentListViewModel.Student);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                TempData.Add("message", "Öğrenci Başarıyla Güncellendi");
                return Redirect("index2");
            }
            TempData["errorMessage"] = "Güncellenemedi";
            return Redirect("index2");

        }
        [HttpPost]
        public IActionResult EditStudentForStudy(StudentStudiedCompanyInfo studentListViewModel)
        {
            if (ModelState.IsValid)
            {

                List<int> beforeToolIds = new List<int>();
                List<StudentCompanyTool> studentCompanyToolList = _studentCompanyToolService.GetAllByStudentCompanyId(studentListViewModel.StudentCompany.StudentCompanyId);
                studentCompanyToolList.ForEach(s => beforeToolIds.Add(s.ToolId));
                var toolIdForDelete = beforeToolIds.Except(studentListViewModel.ToolIds);
                var toolIdForAdd = studentListViewModel.ToolIds.Except(beforeToolIds);
                foreach (var item in toolIdForDelete)
                {
                    try
                    {
                        _studentCompanyToolService.Delete(studentCompanyToolList.Where(c => c.StudentCompanyId == studentListViewModel.StudentCompany.StudentCompanyId && c.ToolId == item).FirstOrDefault());
                    }
                    catch (System.Exception)
                    {
                        TempData["errorMessage"] = "Kullanıcı Toollarında Silme Hatası";
                        return Redirect("index2");
                    }

                }
                foreach (var item in toolIdForAdd)
                {
                    try
                    {
                        _studentCompanyToolService.Add(new StudentCompanyTool { StudentCompanyId = studentListViewModel.StudentCompany.StudentCompanyId,ToolId = item });
                    }
                    catch (System.Exception)
                    {
                        TempData["errorMessage"] = "Kullanıcı Toollarında Ekleme Hatası";
                        return Redirect("index2");
                    }
                }
                try
                {
                    _studentCompanyService.Update(studentListViewModel.StudentCompany);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                TempData["message"] = "Öğrenci Çalışma Bilgileri Başarıyla Güncellendi";
                return Redirect("index2");

            }
            return null;
        }
        [HttpPost]
        public IActionResult DeleteStudentForStudy(StudentStudiedCompanyInfo studentListViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentCompanyService.Delete(new StudentCompany { StudentCompanyId = studentListViewModel.StudentCompany.StudentCompanyId });
                }
                catch (System.Exception)
                {

                    throw;
                }
                return Redirect("index2");
            }
            return null;
        }
        public IActionResult CreateStudentForStudy()
        {
            var StudentId = 0;
            SetStudentId(ref StudentId);
            var companies = _companyService.GetAll();
            var toolList = _toolService.GetAll();
            var fields = _fieldService.GetAll();
            var studentStudyCreateModel = new StudentStudyCreateViewModel
            {
                Companies = companies,
                ToolList = toolList,
                Fields = fields,
                StudentId = StudentId 
            };
            return View(studentStudyCreateModel);
        }
        [HttpPost]
        public  IActionResult CreateStudentForStudy(StudentStudyCreateViewModel studentStudyCreate)
        {
            if (ModelState.IsValid)
            {
                //add to studentCompany
                try
                {
                    _studentCompanyService.Add(studentStudyCreate.StudentCompany);
                }
                catch (System.Exception)
                {

                    throw new System.Exception("Çalışan bilgisi eklenemedi");
                }
                //add to 
                var studentCompanyId = _studentCompanyService.GetByStudentId(studentStudyCreate.StudentCompany.StudentId).Where(sc => sc.CompanyId == studentStudyCreate.StudentCompany.CompanyId).FirstOrDefault().StudentCompanyId;
                foreach (var item in studentStudyCreate.ToolIds)
                {
                    _studentCompanyToolService.Add(new StudentCompanyTool { StudentCompanyId = studentCompanyId , ToolId = item});
                }

            }
            return Redirect("index2");
        }
    }
}
