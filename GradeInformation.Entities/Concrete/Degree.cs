using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Degree : IEntity
    {
        [Key]
        public int DegreeId { get; set; }
        [MaxLength(50)]
        public string DegreeName { get; set; }
        public Faculty Faculty { get; set; }
    }
}
