using GradeInformation.Business.Abstract;
using GradeInformation.DataAccess.Abstract;
using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Concrete
{
    public class SectorCompanyManager : ISectorCompanyService
    {
        private ISectorCompanyDal _sectorCompanyDal;
        public SectorCompanyManager(ISectorCompanyDal sectorCompanyDal)
        {
            _sectorCompanyDal = sectorCompanyDal;
        }

        public void Add(SectorCompany sectorCompany)
        {
            _sectorCompanyDal.Add(sectorCompany);
        }

        public void Delete(SectorCompany sectorCompany)
        {
            _sectorCompanyDal.Delete(sectorCompany);
        }

        public List<SectorCompany> GetAll()
        {
            return _sectorCompanyDal.GetAll();
        }

        public List<SectorCompany> GetByCompanyId(int company)
        {
            return _sectorCompanyDal.GetAll(c => c.CompanyId == company);
        }

        public List<SectorCompany> GetById(int sectorCompanyId)
        {
            return _sectorCompanyDal.GetAll(s => s.SectorCompanyId == sectorCompanyId);
        }

        public List<SectorCompany> GetBySectorId(int sectorId)
        {
            return _sectorCompanyDal.GetAll(s => s.SectorId == sectorId);
        }

        public void SetTopSectors(ref ConcurrentDictionary<string, int> topSectors, List<int> studentCompanyIdList)
        {
            List<SectorCompany> sectorCompanies = _sectorCompanyDal.GetAllWithAllFields();
            foreach (var companyId in studentCompanyIdList)
            {
                foreach (var sectorCompany in sectorCompanies)
                {
                    if (sectorCompany.CompanyId == companyId)
                    {
                        topSectors.AddOrUpdate(sectorCompany.Sector.SectorName, 1, (k, v) => v + 1);
                    }

                }

            }
        }

        public void Update(SectorCompany sectorCompany)
        {
            _sectorCompanyDal.Update(sectorCompany);
        }
    }
}
