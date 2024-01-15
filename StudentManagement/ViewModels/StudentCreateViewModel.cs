using StudentManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "请输入名字")]
        [MaxLength(50, ErrorMessage = "名字的长度不能超过50个字符")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "班级名称")]
        public ClassNameEnum? Classname { get; set; }

        [Display(Name = "电子邮件")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
    ErrorMessage = "邮箱的格式不正确")]
        public string Email { get; set; }

        [Display(Name ="头像")]
        public IFormFile Photo { get; set; }
    }
}
