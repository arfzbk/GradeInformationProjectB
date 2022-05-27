using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IStudentCompanyToolService
    {
        List<StudentCompanyTool> GetAllByStudentCompanyId(int studentCompanyId);
        List<StudentCompanyTool> GetAllByStudentIdWithAllField(List<int> studentCompanyIdList);
        void Delete(StudentCompanyTool studentCompanyTool);
        void Add(StudentCompanyTool studentCompanyTool);
    }
}
