using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IDegreeService
    {
        Degree GetById(int id);
        Degree GetDegreeByName(string degreeName);
        Degree GetDegreeByNameWithFaculty(string degreeName);
    }
}
