using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Company : IEntity
    {
        [Key]
        public int CompanyId { get; set; }
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public int CompanyCapacity { get; set; }
        public City City { get; set; }
        public List<CompanyField> CompanyFields { get; set; }
        public List<SectorCompany> SectorCompanies { get; set; }
        public List<StudentCompany> StudentCompanies { get; set; }
    }
}
