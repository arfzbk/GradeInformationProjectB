using GradeInformation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeInformation.Entities.Concrete
{
    public class Sector : IEntity
    {
        [Key]
        public int SectorId { get; set; }
        [MaxLength(50)]
        public string SectorName { get; set; }
        public List<SectorCompany> SectorCompanies { get; set; }
    }
}
