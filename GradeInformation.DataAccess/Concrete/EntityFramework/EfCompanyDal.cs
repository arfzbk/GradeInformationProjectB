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
    public class EfCompanyDal : EfEntityRepositoryBase<Company, GradeInformationContext>, ICompanyDal
    {
        public List<Company> GetAllWithAllFields()
        {
            using (var context = new GradeInformationContext())
            {
                return context.Companies.Include(x => x.City).ToList();
            }
        }
    }
}
