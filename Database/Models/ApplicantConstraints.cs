namespace Database.Models
{
    /// <summary>Ограничения полей для <see cref="Applicant"/></summary>
    public static class ApplicantConstraints
    {
        public const int MaxLength = 50;
        public const int MinAge = 18;
        public const int MaxAge = 21;
        public const int MinScore = 150;
    }
}
