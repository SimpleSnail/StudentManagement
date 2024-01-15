using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public ViewResult Details(int? id)//可空类型
        {
            //return $"id={id},名字为{Name}";
            //实例化HomeDetailsViewModel并存储Student详细信息和PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id ?? 1),
                PageTitle = "Student Details"
            };//初始化ViewModel

            //将ViewModel对象传递给View()方法
            return View(homeDetailsViewModel);
        }
        public ViewResult Index()
        {
            //查询所有的学生信息
            var model = _studentRepository.GetAllStudents();
            //将学生列表传递到视图
            return View(model);
        }
        public ViewResult test()
        {
            var model = _studentRepository.GetAllStudents();
            //将学生列表传递到视图
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel modle) 
        {
            if(ModelState.IsValid) //会检查是否添加图片
            {
                string uniqueFileName = null;
                if (modle.Photo!=null)
                {
                    string uploadsFodler = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName=Guid.NewGuid().ToString()+"_"+modle.Photo.FileName;
                    string filePath=Path.Combine(uploadsFodler, uniqueFileName);
                    modle.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Student newstudent = new Student
                {
                    Name = modle.Name,
                    Email = modle.Email,
                    Classname = modle.Classname,
                    PhotoPath = uniqueFileName

                };
                _studentRepository.Add(newstudent);
                //Student newstudent = _studentRepository.AddStudent(student);
                return RedirectToAction("Details", new { id = newstudent.Id });
            }
            
            return View();
        }
    }
}
