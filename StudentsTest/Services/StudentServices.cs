using Microsoft.EntityFrameworkCore;
using StudentsTest.Entities;
using StudentsTest.Infrastructure;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;


namespace StudentsTest.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepository<Student> repository;

        private readonly Dictionary<int, string> propgressList;

        public StudentServices(IRepository<Student> repository)
        {
            this.repository = repository;
            propgressList = new Dictionary<int, string> {
                { 2, "Неудовлетворительно"},
                { 3, "Удовлетворительно"},
                { 4, "Хорошо"},
                { 5, "Отлично"}
            };
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await repository.All().ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await repository.All().FirstOrDefaultAsync(x => x.Id == id);

        }
        
        public async Task<Student> CreateOrUpdateStudent(StudentDTO studentDTO)
        {
            var student = await repository.All().FirstOrDefaultAsync(x => x.Id == studentDTO.Id);
            if (student == null) return await CreateStudent(studentDTO);
            else return await UpdateStudent(studentDTO);
        }      

        public async Task DeleteStudent(int id)
        {
            var student = await repository.All().FirstOrDefaultAsync(x => x.Id == id);
            repository.Delete(student);
        }
        private async Task<Student> CreateStudent(StudentDTO studentDTO)
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

            var result = await repository.Add(student);
            return result;
        }

        private async Task<Student> UpdateStudent(StudentDTO studentDTO)
        {
            var student = await repository.All().FirstOrDefaultAsync(x => x.Id == studentDTO.Id);
            student.BirthDate = studentDTO.BirthDate;
            student.FIO = $"{studentDTO.LastName} {studentDTO.MiddleName} {studentDTO.FirstName}";
            student.FirstName = studentDTO.FirstName;
            student.MiddleName = studentDTO.MiddleName;
            student.LastName = studentDTO.LastName;
            student.Progress = GetValue(studentDTO.Rataig);

            return await repository.Update(student);
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
