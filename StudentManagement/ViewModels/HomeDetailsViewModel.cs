using StudentManagement.Models;

namespace StudentManagement.ViewModels
{/// <summary>
/// 封装Student和PageTitle
/// </summary>
    public class HomeDetailsViewModel
    {
        public Student Student { get; set; }
        public string PageTitle { get; set; }
    }
}
