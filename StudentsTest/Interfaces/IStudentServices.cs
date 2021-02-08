using StudentsTest.Entities;
using System.Threading.Tasks;

namespace StudentsTest.Services
{
    public interface IStudentServices
    {
        void Deletetudent(Student student);
        Task SetStudent(StudentDTO studentDTO);
    }
}