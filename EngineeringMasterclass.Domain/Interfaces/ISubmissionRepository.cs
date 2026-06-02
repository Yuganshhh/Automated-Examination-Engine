using EngineeringMasterclass.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngineeringMasterclass.Domain.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<List<Submission>> GetAllSubmissionsAsync();
        Task<Submission> GetSubmissionByIdAsync(int id);
        Task<Submission> CreateSubmissionAsync(Submission submission);
        Task SaveChangesAsync();
    }
}