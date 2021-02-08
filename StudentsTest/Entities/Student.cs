using System;

namespace StudentsTest.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FIO { get; set; }
        public DateTime BirthDate { get; set; }
        public string Progress { get; set; }      
    }
}
