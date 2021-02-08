using Microsoft.EntityFrameworkCore;
using StudentsTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsTest.Infrastructure
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { set; get; }
    }
}
