using GradeInformation.DataAccess.Abstract;
using GradeInformation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Concrete.EntityFramework
{
    public class EfStudentCompanyToolDal : EfEntityRepositoryBase<StudentCompanyTool, GradeInformationContext>, IStudentCompanyToolDal
    {
        public List<StudentCompanyTool> GetAllWithAllFields(List<int> studentCompanyIds)
        {
            using (var context = new GradeInformationContext())
            {
                return context.StudentCompanyTools.Where(s => studentCompanyIds.Contains(s.StudentCompanyId))
                    .Include(x => x.Tool)
                    .Include(x => x.StudentCompany).ToList();
            }
        }
    }
}
