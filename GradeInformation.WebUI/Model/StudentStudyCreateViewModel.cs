using GradeInformation.Entities.Concrete;
using System.Collections.Generic;

namespace GradeInformation.WebUI.Model
{
    public class StudentStudyCreateViewModel
    {
        public List<Company> Companies { get; internal set; }
        public List<Tool> ToolList { get; internal set; }
        public List<Field> Fields { get; internal set; }
        public StudentCompany StudentCompany{ get; set; }
        public List<int> ToolIds { get; set; }
        public int StudentId { get; internal set; }
    }
}
