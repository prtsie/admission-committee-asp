using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public sealed class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime from;
        private readonly DateTime to;

        public DateRangeAttribute(int minAge, int maxAge)
        {
            if (minAge > maxAge)
            {
                throw new ArgumentException("Минимальный возраст больше максимального");
            }
            from = DateTime.Now.AddYears(-maxAge - 1).Date;
            to = DateTime.Now.AddYears(-minAge).Date;
        }

        public override bool IsValid(object? value)
        {
            if (value is DateTime date && from <= date && date < to)
            {
                return true;
            }
            ErrorMessage = $"Дата должна быть в пределах от {from.ToShortDateString()} до {to.ToShortDateString()}";
            return false;
        }
    }
}
