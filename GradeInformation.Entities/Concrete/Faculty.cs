using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Faculty : IEntity
    {
        [Key]
        public int FacultyId { get; set; }
        [MaxLength(50)]
        public string FacultyName { get; set; }
        public List<Degree> Degrees { get; set; }
    }
}
