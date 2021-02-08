using StudentsTest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsTest.Services
{
    public interface IStudentServices
    {
        Task DeleteStudent(int id);       
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);        
        Task<Student> CreateOrUpdateStudent(StudentDTO studentDTO);
    }
}