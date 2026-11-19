using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSchedule.Core.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название Обязательно")]
        [MinLength(1, ErrorMessage = "Минимум 1 символ")]
        [MaxLength(30, ErrorMessage = "Максимум 30 символов")]
        [Display(Name = "Название расписания")]
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<LessonSlot>? LessonSlots {  get; set; }
    }
}
