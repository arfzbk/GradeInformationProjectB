using GradeInformation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GradeInformation.WebUI.Model
{
    public class StudentStudiedCompanyInfo
    {
        public Student Student { get; set; }
        public int CityId { get; set; }
        public string DegreeName { get; set; }
        public List<City> Cities { get; internal set; }
        public StudentCompany StudentCompany { get; set; }
        public List<int> ToolIds { get; set; }
        public List<StudentCompanyTool> StudentCompanyToolList { get; internal set; }
        public List<Field> Fields { get; set; }
        public int FieldId { get; set; }
        public List<Company> Companies { get; set; }
        public int CompanyId { get; set; }
        public List<Tool> ToolList { get; internal set; }
    }
}
