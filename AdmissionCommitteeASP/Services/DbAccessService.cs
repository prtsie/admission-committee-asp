using System.Data.Entity;
using Database;
using Database.Helpers;
using Database.Models;

namespace AdmissionCommitteeASP.Services
{
    /// <summary>
    /// Сервис для доступа к базе данных через контекст <see cref="CommitteeContext"/>
    /// </summary>
    /// <param name="context">контекст базы данных</param>
    public class DbAccessService(CommitteeContext context, Serilog.ILogger logger)
    {
        /// <summary>Запрашивает всех абитуриентов из БД</summary>
        /// <returns>Список абитуриентов</returns>
        public async Task<IEnumerable<Applicant>> GetApplicants()
        {
            return await context.Applicants.ToListAsync();
        }

        /// <summary>Добавляет абитуриента в БД</summary>
        /// <param name="applicant">абитуриент для добавления</param>
        public async Task AddApplicant(Applicant applicant)
        {
            context.Applicants.Add(applicant);
            await context.SaveChangesAsync();
            logger.Information("Добавлен {@applicant}", applicant);
        }

        /// <summary>Обновляет данные абитуриента в БД</summary>
        /// <param name="applicant">абитуриент с обновленными данными</param>
        public async Task UpdateApplicantAsync(Applicant applicant)
        {
            var toUpdate = await FindApplicantAsync(applicant.Id);
            if (toUpdate != null)
            {
                logger.Information("Изменён {@toUpdate}, новые значения: {@applicant}", toUpdate, applicant);
                context.Entry(toUpdate).CurrentValues.SetValues(applicant);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>Удаляет абитуриента из БД</summary>
        /// <param name="id">id абитуриента</param>
        public async Task DeleteApplicantAsync(Guid id)
        {
            var toDelete = await FindApplicantAsync(id);
            if (toDelete != null)
            {
                logger.Information("Удалён {@applicant}", toDelete);
                context.Applicants.Remove(toDelete);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>Находит абитуриента по id</summary>
        /// <param name="id">id абитуриента</param>
        /// <returns><see cref="Applicant"/>, присоединенный к контексту</returns>
        public async Task<Applicant?> FindApplicantAsync(Guid id) => await context.Applicants.FindAsync(id);

        /// <summary>Генерация абитуриентов в БД</summary>
        /// <param name="count">количество абитуриентов для генерации</param>
        public async void GenerateApplicantsToDb(int count)
        {
            context.Applicants.AddRange(DataGenerator.GenerateApplicants(30));
            await context.SaveChangesAsync();
        }
    }
}
