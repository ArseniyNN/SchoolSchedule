using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSchedule.Core
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ФИО обязательно")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        [MaxLength(100, ErrorMessage = "Максимум 100 символов")]
        [Display(Name = "ФИО педагога")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Колличество часов обязательно")]
        [Display(Name = "Максимальное количество часов занятости на неделю")]
        public int MaxHoursPerWeek { get; set; }
        public IEnumerable<LessonSlot> Lesson { get; set; } = new List<LessonSlot>();
    }
}
