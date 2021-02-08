using StudentsTest.Entities;
using StudentsTest.Infrastructure;
using System;
using System.Collections.Generic;
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

        public void Deletetudent(Student student)
        {
            repository.Delete(student);
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
