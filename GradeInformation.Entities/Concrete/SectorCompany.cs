using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class SectorCompany : IEntity
    {
        [Key]
        public int SectorCompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        [ForeignKey("SectorId")]
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public Company Company { get; set; }
    }
}
