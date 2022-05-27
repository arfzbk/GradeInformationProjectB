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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public void Add(Student student)
        {
            _studentDal.Add(student);   
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }

        public List<Student> GetAll()
        {
            return _studentDal.GetAll();
        }

        public List<Student> GetByCityId(int cityId)
        {
            return _studentDal.GetAll(c => c.City.CityId == cityId);
        }

        public List<Student> GetByDegreeId(int degreeId)
        {
            return _studentDal.GetAll(d => d.Degree.DegreeId == degreeId);
        }

        public Student GetById(int id)
        {
            return _studentDal.Get(s => s.StudentId == id); 
        }

        public Student GetByIdWithAllFields(int id)
        {
            return _studentDal.GetAllWithFieldsByStudentId(id); 
        }

        public Student GetByStudentNumber(string studentNo)
        {
            return _studentDal.GetByStudentNumber(studentNo);
        }

        public Student GetByTcNo(string tcNo)
        {
            return _studentDal.GetByTcNo(tcNo);
        }

        public void Update(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
