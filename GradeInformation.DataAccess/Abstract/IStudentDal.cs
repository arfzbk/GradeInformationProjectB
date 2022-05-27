using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        public Student GetAllWithFieldsByStudentId(int studentId);
        public Student GetByTcNo(string tcNo);
        public Student GetByStudentNumber(string studentNumber);
    }
}
