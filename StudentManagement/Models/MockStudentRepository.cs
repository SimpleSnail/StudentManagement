namespace StudentManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;//私有字段
        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "章北海", Classname = ClassNameEnum.SecondGrade, Email = "aaa@qq.com" },
                new Student() { Id = 2, Name = "罗辑", Classname = ClassNameEnum.FirstGrade, Email = "bbb@qq.com" },
                new Student() { Id = 3, Name = "储岩", Classname = ClassNameEnum.FirstGrade, Email = "ccc@qq.com" },
                new Student() { Id = 4, Name = "云天明", Classname = ClassNameEnum.FirstGrade, Email = "ddd@qq.com" },
                new Student() { Id = 5, Name = "汪淼", Classname = ClassNameEnum.ThirdGrade, Email = "eee@qq.com" }
            };

        }

        public Student Add(Student student)
        {
            student.Id = _studentList.Max(s => s.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(a => a.Id == id);
        }
        public Student Delete(int id)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                _studentList.Remove(student);

            }
            return student;

        }
        public Student Update(Student updateStudent)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == updateStudent.Id);

            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.Classname = updateStudent.Classname;
            }
            return student;
        }

    }
}
