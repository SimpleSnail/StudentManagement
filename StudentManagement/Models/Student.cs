﻿using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    /// <summary>
    /// 学生模型
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassNameEnum? Classname { get; set; }
        public string Email { get; set; }
        public string  PhotoPath { get; set; }
    }
}
