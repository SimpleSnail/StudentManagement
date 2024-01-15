namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
       public Student GetStudent(int id);
        public IEnumerable<Student> GetAllStudents();
        public Student Add(Student student);
        public Student Update(Student updatestudent);
        public Student Delete(int id);
    }
}
