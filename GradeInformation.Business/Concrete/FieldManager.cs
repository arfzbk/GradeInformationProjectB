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
    public class FieldManager : IFieldService
    {
        private IFieldDal _fieldDal;
        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal; 
        }
        public List<Field> GetAll()
        {
            return _fieldDal.GetAll();
        }

        public Field GetById(int item)
        {
            return _fieldDal.Get(i => i.FieldId == item);
        }
    }
}
