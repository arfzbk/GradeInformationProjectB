using GradeInformation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeInformation.Business.Abstract
{
    public interface IStudentService
    {
        List<Student> GetAll(); 
        Student GetById(int id);
        Student GetByTcNo(string tcNo);
        Student GetByStudentNumber(string studentNo);
        public Student GetByIdWithAllFields(int id);
        List<Student> GetByDegreeId(int degreeId);    
        List<Student> GetByCityId(int cityId);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
