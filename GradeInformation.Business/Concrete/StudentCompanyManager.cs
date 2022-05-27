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
    public class StudentCompanyManager : IStudentCompanyService
    {
        private IStudentCompanyDal _studentCompanyDal;
        public StudentCompanyManager(IStudentCompanyDal studentCompanyDal)
        {
            _studentCompanyDal = studentCompanyDal;
        }
        public void Add(StudentCompany studentCompany)
        {
            _studentCompanyDal.Add(studentCompany);
        }

        public void Delete(StudentCompany studentCompany)
        {
            _studentCompanyDal.Delete(studentCompany);
        }

        public List<StudentCompany> GetAll()
        {
            return _studentCompanyDal.GetAll();
        }


        public List<StudentCompany> GetByCompanyId(int company)
        {
            return _studentCompanyDal.GetAll(c => c.CompanyId == company);  
        }

        public StudentCompany GetById(int studentCompanyId)
        {
            return _studentCompanyDal.Get(sc => sc.StudentCompanyId == studentCompanyId);
        }

        public List<StudentCompany> GetByStudentId(int studentId)
        {
            return _studentCompanyDal.GetAllWithFieldsByStudentId(studentId);
        }

        public void Update(StudentCompany studentCompany)
        {
            _studentCompanyDal.Update(studentCompany);
        }
        public decimal AverageStudyDays()
        {
            decimal averageStudyTime = 0;
            List<StudentCompany> allStudentCompany = _studentCompanyDal.GetAll();
            foreach (var studentCompany in allStudentCompany)
            {
                if (studentCompany.StartDate == null)
                    throw new Exception("Başlangıç Tarihinin Bulunması Zorunludur");

                var startDate = studentCompany.StartDate;
                var endDate = studentCompany.FinishDate ?? DateTime.Now;
                TimeSpan ts = (TimeSpan)(endDate - startDate);
                averageStudyTime += ts.Days;
            }
            averageStudyTime = averageStudyTime / allStudentCompany.Select(x => x.StudentId).Distinct().ToList().Count;
            return averageStudyTime;
        }
        public List<int> GetCompanyIds()
        {
            List<int> studentCompanyIds = _studentCompanyDal.GetAll().Select(s => s.CompanyId).ToList();
            return studentCompanyIds;
        }
    }
}
