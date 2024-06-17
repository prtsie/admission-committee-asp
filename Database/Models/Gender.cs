using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    /// <summary>Пол для <see cref="Applicant"/></summary>
    public enum Gender
    {
        [Display(Name = "Неизвестен")]
        Unknown,
        [Display(Name = "Мужской")]
        Male,
        [Display(Name = "Женский")]
        Female,
        [Display(Name = "Боевой вертолёт")]
        AttackHelicopter,
        [Display(Name = "Пикачу")]
        Pikachu
    }
}
