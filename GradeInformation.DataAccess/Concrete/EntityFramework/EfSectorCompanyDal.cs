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
    public class EfSectorCompanyDal : EfEntityRepositoryBase<SectorCompany, GradeInformationContext>, ISectorCompanyDal
    {
        public List<SectorCompany> GetAllWithAllFields()
        {
            using (var context = new GradeInformationContext())
            {
                return context.SectorCompanies.Include(x => x.Sector).ToList();
            }
        }
    }
}
