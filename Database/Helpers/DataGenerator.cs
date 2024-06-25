using Database.Models;

namespace Database.Helpers
{
    /// <summary>Генератор объектов <see cref="Applicant"/></summary>
    public static class DataGenerator
    {
        /// <summary>Генерирует валидных абитуриентов</summary>
        /// <param name="count">количество абитуриентов для генерации</param>
        /// <returns>Массив абитуриентов длиной <paramref name="count"/></returns>
        public static Applicant[] GenerateApplicants(int count)
        {
            var applicants = new Applicant[count];
            var random = new Random();
            var formOfEducationValues = Enum.GetValues<FormOfEducation>();
            var genderValues = Enum.GetValues<Gender>();
            var now = DateTime.Now;
            var minYear = now.Year - ApplicantConstraints.MaxAge;
            var maxYear = now.Year - ApplicantConstraints.MinAge;
            string[] names = ["Алёша", "Вася", "Иннокентий", "Олег", "Доброгей", "Даздраперма", "Наруто"];
            string[] surnames = ["Иванов", "Каерчывпак", "Абдулгаджиев"];
            string?[] patronymics = ["Магомедович", "Валентинович", "Евсеевич", "Аыуыаеич", null];
            for (var i = 0; i < count; i++)
            {
                var year = random.Next(minYear, maxYear + 1);
                int month;
                int day;
                if (year == minYear)
                {
                    month = random.Next(now.Month, 12 + 1);
                    var minDay = month == now.Month ? now.Day : 1;
                    day = random.Next(minDay, DateTime.DaysInMonth(year, month) + 1);
                }
                else if (year == maxYear)
                {
                    month = random.Next(1, now.Month + 1);
                    var maxDay = month == now.Month ? now.Day : DateTime.DaysInMonth(year, month);
                    day = random.Next(1, maxDay);
                }
                else
                {
                    month = random.Next(1, 12 + 1);
                    day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
                }
                applicants[i] = new Applicant
                {
                    Name = names[random.Next(names.Length)],
                    Surname = surnames[random.Next(surnames.Length)],
                    Patronymic = patronymics[random.Next(patronymics.Length)],
                    BirthDay = new DateTime(year, month, day),
                    FormOfEducation = formOfEducationValues[random.Next(formOfEducationValues.Length)],
                    Gender = genderValues[random.Next(genderValues.Length)],
                    ItScore = random.Next(101),
                    RussianScore = random.Next(101),
                    MathScore = random.Next(101),
                };
            }
            return applicants;
        }
    }
}
