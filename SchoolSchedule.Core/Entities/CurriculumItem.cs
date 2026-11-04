using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSchedule.Core
{
    public class CurriculumItem
    {
        public int Id { get; set; }
        public int ClassId {  get; set; }
        public Class? Class { get; set; }
        public int SubjectId {  get; set; }
        public Subject? Subject { get; set; }
        [Required(ErrorMessage = "Часы обязательны")]
        [Display(Name = "Часов в неделю")]
        [Range(1 ,15 , ErrorMessage ="Колличество часов должно быть от 1 до 15")]
        public  int HoursPerWeek { get; set; }
    }
}
