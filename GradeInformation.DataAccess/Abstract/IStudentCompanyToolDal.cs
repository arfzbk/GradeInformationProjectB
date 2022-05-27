using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Abstract
{
    public interface IStudentCompanyToolDal : IEntityRepository<StudentCompanyTool>
    {
        List<StudentCompanyTool> GetAllWithAllFields(List<int> studentCompanyIds);
    }
}
