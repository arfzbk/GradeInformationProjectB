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
    public class EfStudentCompanyDal : EfEntityRepositoryBase<StudentCompany, GradeInformationContext>, IStudentCompanyDal
    {
        public List<StudentCompany> GetAllWithFieldsByStudentId(int studentId)
        {
            using (var context = new GradeInformationContext())
            {
                return context.StudentCompanies.Where(s => s.StudentId == studentId).Include(x => x.Field).Include(x => x.Student).Include(x => x.Company).ThenInclude(x => x.CompanyFields).ToList();
            }
        }
    }
}
