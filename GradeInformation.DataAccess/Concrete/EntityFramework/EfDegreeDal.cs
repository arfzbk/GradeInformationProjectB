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
    public class EfDegreeDal : EfEntityRepositoryBase<Degree, GradeInformationContext>, IDegreeDal
    {
        public Degree GetDegreeWithFaculty(string degreeName)
        {
            using (var context = new GradeInformationContext())
            {
                return context.Set<Degree>().Where(d => d.DegreeName == degreeName)
                    .Include(d => d.Faculty).FirstOrDefault();
            }
        }
    }
}
