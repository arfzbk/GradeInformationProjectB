using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class StudentCompany : IEntity
    {
        [Key]
        public int StudentCompanyId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Student Student { get; set; }
        public Company Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public decimal Salary{ get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
    }
}
