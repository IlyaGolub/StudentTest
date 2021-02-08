using StudentsTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsTest.Services
{
    public interface IStudentServices
    {
        Task DeleteStudent(int id);
        Task<Student> CreateStudent(StudentDTO studentDTO);
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        void UpdateStudent(Student student);
    }
}