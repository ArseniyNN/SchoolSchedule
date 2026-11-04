using System.ComponentModel.DataAnnotations;

namespace SchoolSchedule.Core
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название Обязательно")]
        [MinLength(2, ErrorMessage = "Минимум 2 символа")]
        [MaxLength(50, ErrorMessage = "Максимум 50 символов")]
        [Display(Name = "Название предмета")]
        public string Name { get; set; } = "";
    }
}
