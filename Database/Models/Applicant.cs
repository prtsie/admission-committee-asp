using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    /// <summary>
    /// Класс абитуриента
    /// </summary>
    public sealed class Applicant : ICloneable
    {
        [Display(Name = "Id")]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Required]
        [MaxLength(ApplicantConstraints.MaxLength)]
        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(ApplicantConstraints.MaxLength)]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }

        [MaxLength(ApplicantConstraints.MaxLength)]
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        [Required]
        [DateRange(ApplicantConstraints.MinAge, ApplicantConstraints.MaxAge)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        ///<summary><inheritdoc cref="Models.FormOfEducation"/></summary>
        [Display(Name = "Форма обучения")]
        public FormOfEducation FormOfEducation { get; set; }

        ///<summary><inheritdoc cref="Models.Gender"/></summary>
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Range(0, 100)]
        [Display(Name = "Баллы по математике")]
        public int MathScore { get; set; }

        [Range(0, 100)]
        [Display(Name = "Баллы по русскому")]
        public int RussianScore { get; set; }

        [Range(0, 100)]
        [Display(Name = "Баллы по информатике")]
        public int ItScore { get; set; }

        [Display(Name = "Сумма баллов")]
        public int TotalScore => MathScore + RussianScore + ItScore;

        public object Clone() => MemberwiseClone();
    }
}
