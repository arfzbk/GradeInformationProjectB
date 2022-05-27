using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface ISectorCompanyService
    {
        List<SectorCompany> GetAll(); 
        List<SectorCompany> GetById(int sectorCompanyId);
        List<SectorCompany> GetBySectorId(int sectorId);    
        List<SectorCompany> GetByCompanyId(int company);
        void Add(SectorCompany sectorCompany);
        void Update(SectorCompany sectorCompany);
        void Delete(SectorCompany sectorCompany);
        void SetTopSectors(ref ConcurrentDictionary<string, int> topSectors, List<int> studentCompanyIdList);
    }
}
