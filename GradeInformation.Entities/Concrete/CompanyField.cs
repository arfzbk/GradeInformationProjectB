using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class CompanyField : IEntity
    {
        [Key]
        public int CompanyFieldId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("FieldId")]
        public Field Field { get; set; }
    }
}
