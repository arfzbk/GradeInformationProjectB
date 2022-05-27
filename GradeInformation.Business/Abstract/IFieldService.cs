using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IFieldService
    {
        List<Field> GetAll();
        Field GetById(int item);
    }
}
