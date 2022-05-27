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
    public class FacultyManager : IFacultyService
    {
        private IFacultyDal _facultyDal;
        public FacultyManager(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        public List<Faculty> GetAll()
        {
           return _facultyDal.GetAll();
        }
    }
}
