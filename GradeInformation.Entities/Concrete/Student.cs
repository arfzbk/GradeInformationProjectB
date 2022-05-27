using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Student : IEntity
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(12)]
        [Required]
        public string StudentNumber { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string SurName { get; set; }
        [MaxLength(50)]
        public string NewSurname { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int DegreeId { get; set; }
        [ForeignKey("DegreeId")]
        public Degree Degree { get; set; }
        [Required]
        public DateTime DateOfGrade { get; set; }
        [MaxLength(12)]
        [Required(ErrorMessage ="Tc Zorunludur")]
        public string Tc { get; set; }
        [Required]
        public decimal Gpa { get; set; }
        [MaxLength(2)]
        public string Gender { get; set; }
        public int CityId { get; set; }
        [MaxLength(50)]
        public City City { get; set; }

        public List<StudentCompany> StudentCompanies { get; set; }

    }
}
