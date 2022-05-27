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
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal; 
        }
        public List<City> GetAll()
        {
            return _cityDal.GetAll();
        }

        public City GetCityById(int cityId)
        {
            return _cityDal.Get(c => c.CityId == cityId);
        }
    }
}
