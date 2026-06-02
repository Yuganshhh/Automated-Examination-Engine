using EngineeringMasterclass.Domain.Interfaces;
using EngineeringMasterclass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngineeringMasterclass.Dal.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly DataContext context;

        // Inject the DataContext using Dependency Injection
        public SubmissionRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Submission> GetSubmissionByIdAsync(int id)
        {
            return await context.Submissions 
                .Include(s => s.Student)
                .Include(s => s.Assignment)
                .FirstOrDefaultAsync(s => s.SubmissionId == id);
        }

        public async Task<List<Submission>> GetAllSubmissionsAsync()
        {
            return await context.Submissions.ToListAsync();
        }

        public async Task<Submission> CreateSubmissionAsync(Submission submission)
        {
            context.Submissions.Add(submission);
            return await Task.FromResult(submission); 
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}