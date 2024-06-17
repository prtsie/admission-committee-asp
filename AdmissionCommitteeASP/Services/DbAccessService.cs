using System.Data.Entity;
using Database;
using Database.Helpers;
using Database.Models;

namespace AdmissionCommitteeASP.Services
{
    public class DbAccessService(CommitteeContext context)
    {
        public async Task<IEnumerable<Applicant>> GetApplicants()
        {
            return await context.Applicants.ToListAsync();
        }

        public async void AddApplicant(Applicant applicant)
        {
            context.Applicants.Add(applicant);
            await context.SaveChangesAsync();
        }

        public async void UpdateApplicantAsync(Applicant applicant)
        {
            var toUpdate = await context.Applicants.FindAsync(applicant.Id);
            if (toUpdate != null)
            {
                context.Entry(context.Applicants.Attach(toUpdate)).CurrentValues.SetValues(applicant);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Абитуриента с таким id не существует.");
            }
        }

        public async void DeleteApplicantAsync(Applicant applicant)
        {
            context.Applicants.Remove(applicant);
            await context.SaveChangesAsync();
        }

        public async void GenerateApplicantsToDb(int count)
        {
            context.Applicants.AddRange(DataGenerator.GenerateApplicants(30));
            await context.SaveChangesAsync();
        }
    }
}
