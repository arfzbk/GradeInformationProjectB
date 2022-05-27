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
    public class StudentCompanyToolManager : IStudentCompanyToolService
    {
        private IStudentCompanyToolDal _studentCompanyToolDal;
        public StudentCompanyToolManager(IStudentCompanyToolDal studentCompanyToolDal)
        {
            _studentCompanyToolDal = studentCompanyToolDal; 
        }

        public void Add(StudentCompanyTool studentCompanyTool)
        {
            _studentCompanyToolDal.Add(studentCompanyTool);
        }

        public void Delete(StudentCompanyTool studentCompanyTool)
        {
            _studentCompanyToolDal.Delete(studentCompanyTool);  
        }

        public List<StudentCompanyTool> GetAllByStudentCompanyId(int studentCompanyId)
        {
            return _studentCompanyToolDal.GetAll(s => s.StudentCompanyId == studentCompanyId);
        }

        public List<StudentCompanyTool> GetAllByStudentIdWithAllField(List<int> studentCompanyIdList)
        {
            List<StudentCompanyTool> result = new List<StudentCompanyTool>();
            result = (_studentCompanyToolDal.GetAllWithAllFields(studentCompanyIdList));
            return result;
        }
    }
}
