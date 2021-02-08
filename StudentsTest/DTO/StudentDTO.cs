using System;

namespace StudentsTest.Entities
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }       
        public DateTime BirthDate { get; set; }
        public int Rataig { get; set; }
    }
}
