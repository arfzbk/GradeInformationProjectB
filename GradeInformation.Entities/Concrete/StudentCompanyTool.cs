using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class StudentCompanyTool : IEntity
    {
        [Key]
        public int StudentCompanyToolId { get; set; }
        [ForeignKey("StudentCompanyId")]
        public int StudentCompanyId { get; set; }
        public StudentCompany StudentCompany { get; set; }
        [ForeignKey("ToolId")]
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}
