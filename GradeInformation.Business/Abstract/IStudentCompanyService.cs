using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IStudentCompanyService
    {
        List<StudentCompany> GetAll(); 
        StudentCompany GetById(int studentCompanyId);
        List<StudentCompany> GetByStudentId(int studentId);    
        List<StudentCompany> GetByCompanyId(int company);
        void Add(StudentCompany studentCompany);
        void Update(StudentCompany studentCompany);
        void Delete(StudentCompany studentCompany);
        public decimal AverageStudyDays();
        public List<int> GetCompanyIds();
    }
}
