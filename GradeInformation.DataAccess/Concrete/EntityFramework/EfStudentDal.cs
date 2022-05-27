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
    public class EfStudentDal : EfEntityRepositoryBase<Student, GradeInformationContext> , IStudentDal
    {
        public Student GetAllWithFieldsByStudentId(int studentId)
        {
            using (var context = new GradeInformationContext())
            {
                return context.Students.Where(s => s.StudentId == studentId)
                    .Include(x => x.Degree)
                    .Include(x => x.City)
                    .Include(x => x.StudentCompanies).ThenInclude(y => y.Field)
                    .Include(x => x.StudentCompanies).ThenInclude(y => y.Company).ThenInclude(z => z.City)
                    .Include(x => x.StudentCompanies).FirstOrDefault();
            }
        }
        public Student GetByTcNo(string tcNo)
        {
            using (var context = new GradeInformationContext())
            {
                return context.Set<Student>().Where(s => s.Tc == tcNo).FirstOrDefault();
            }
        }
        public Student GetByStudentNumber(string studentNumber)
        {
            using (var context = new GradeInformationContext())
            {
                return context.Set<Student>().Where(s => s.StudentNumber == studentNumber).FirstOrDefault();
            }
        }
    }
}
