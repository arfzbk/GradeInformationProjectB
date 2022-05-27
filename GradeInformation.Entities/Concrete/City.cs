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
    public class City : IEntity
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        //public List<Company> Companies { get; set; }
        //public List<Student> Students { get; set; }
    }
}
