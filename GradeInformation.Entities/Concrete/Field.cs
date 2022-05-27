using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Field : IEntity
    {
        [Key]
        public int FieldId { get; set; }
        public List<CompanyField> CompanyFields { get; set; }
        [MaxLength(50)]
        public string FieldName { get; set; }
    }
}
