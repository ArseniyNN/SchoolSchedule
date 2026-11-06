using System.ComponentModel.DataAnnotations;

namespace SchoolSchedule.Core.Entities
{
    public class Class
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название Обязательно")]
        [MinLength(1, ErrorMessage = "Минимум 1 символ")]
        [MaxLength(3, ErrorMessage = "Максимум 3 символа")]
        [Display(Name = "Название класса")]
        public string Name { get; set; } = "";
        public IEnumerable<LessonSlot> Lessons { get; set; } = new List<LessonSlot>();
    }
}
