using GradeInformation.DataAccess.Abstract;
using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Concrete.EntityFramework
{
    public class EfToolDal : EfEntityRepositoryBase<Tool, GradeInformationContext> , IToolDal
    {
    }
}
