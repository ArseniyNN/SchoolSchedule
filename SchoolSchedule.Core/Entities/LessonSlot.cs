using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSchedule.Core.Entities
{
    public class LessonSlot
    {
        public int Id {  get; set; }
        public int ClassId {  get; set; }
        public Class? Class { get; set; }
        public int SubjectId {  get; set; }
        public Subject? Subject { get; set; }
        public int TeacherId {  get; set; }
        public Teacher? Teacher { get; set; }
        public int RoomId {  get; set; }
        public Room? Room { get; set; }
        [Required(ErrorMessage = "Номер урока обязателен")]
        [Display(Name = "Номер урока")]
        [Range(1,8,ErrorMessage ="Номер урока может быть от 1 до 8")]
        public int LessonNumber {  get; set; }
        public DayOfWeek DayWeek {  get; set; }
        public enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }
    }
}
