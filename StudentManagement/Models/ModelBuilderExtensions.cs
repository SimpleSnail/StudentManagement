using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "叶文洁",
                    Classname = ClassNameEnum.FirstGrade,
                    Email = "ywj@qq.com",
                    PhotoPath="ywj.png"
                    
                }
                );
        }
    }
}
