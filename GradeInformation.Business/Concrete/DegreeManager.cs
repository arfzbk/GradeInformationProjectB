using GradeInformation.Business.Abstract;
using GradeInformation.DataAccess.Abstract;
using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Concrete
{
    public class DegreeManager : IDegreeService
    {
        private IDegreeDal _degreeDal;
        public DegreeManager(IDegreeDal degreeDal)
        {
            _degreeDal = degreeDal;
        }
        public Degree GetById(int id)
        {
            return _degreeDal.Get(d => d.DegreeId == id);
        }

        public Degree GetDegreeByName(string degreeName)
        {
            return _degreeDal.Get(d => d.DegreeName == degreeName); 
        }

        public Degree GetDegreeByNameWithFaculty(string degreeName)
        {
            return _degreeDal.GetDegreeWithFaculty(degreeName);
        }
    }
}
