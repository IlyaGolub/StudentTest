using StudentsTest.Entities;
using StudentsTest.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace StudentsTest.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepository<Student> repository;

        private readonly Dictionary<int, string> propgressList;

        public StudentServices()
        {
            propgressList = new Dictionary<int, string> {
                { 2, "Неудовлетворительно"},
                { 3, "Удовлетворительно"},
                { 4, "Хорошо"},
                { 5, "Отлично"}
            };
        }

        public StudentServices(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await repository.All().ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await repository.All().FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task SetStudent(StudentDTO studentDTO)
        {

            var student = new Student
            {
                BirthDate = studentDTO.BirthDate,
                FIO = $"{studentDTO.LastName} {studentDTO.MiddleName} {studentDTO.FirstName}",
                FirstName = studentDTO.FirstName,
                MiddleName = studentDTO.MiddleName,
                LastName = studentDTO.LastName,
                Progress = GetValue(studentDTO.Rataig)
            };

            await repository.Add(student);
        }

        public async Task DeleteStudent(int id)
        {
            var student = await repository.All().FirstOrDefaultAsync(x => x.Id == id);
            repository.Delete(student);
        }

        public void UpdateStudent(Student student)
        {
            var OldStudent = repository.All().FirstOrDefault(x => x.Id == student.Id);

            repository.Update(OldStudent, student);

        }

        private string GetValue(int rating)
        {
            try
            {
                propgressList.TryGetValue(rating, out string result);
                return result;
            }
            catch
            {

                return null;
            }

        }
    }
}
