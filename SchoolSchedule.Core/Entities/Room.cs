using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSchedule.Core
{
    public class Room
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Номер обязателен")]
        [Range (1,5 , ErrorMessage ="Размер числа от 1 до 5 символов")]
        [Display(Name = "Номер кабинета")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Тип кабинета обязателен")]
        [Display(Name = "Тип кабинета")]
        public RoomType Type {  get; set; }
        public enum RoomType 
        {
            Regular,
            ComputerLab,
            ChemistryLab,
            PhysicsLab,
            Gym
        }
        public IEnumerable<LessonSlot> Lesson { get; set; } = new List<LessonSlot> ();
    }
}
