using EngineeringMasterclass.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineeringMasterclass.Services
{
    public class GradingEngineService
    {
        private readonly ISubmissionRepository repository;
        private readonly IEnumerable<IGradingStrategy> graders;

        public GradingEngineService(ISubmissionRepository repository, IEnumerable<IGradingStrategy> graders)
        {
            this.repository = repository;
            this.graders = graders;
        }

        public async Task ProcessSubmissionAsync(int submissionId)
        {
            var submission = await repository.GetSubmissionByIdAsync(submissionId);
            
            if (submission == null) return;

            var grader = graders.FirstOrDefault(g => g.AssignmentType == submission.Assignment.AssignmentType);

            if (grader == null)
            {
                submission.Feedback = "System Error: Unrecognized assignment type.";
                submission.Grade = 0.0;
            }
            else
            {
               
                await grader.GradeAsync(submission);
            }

            await repository.SaveChangesAsync();
        }
    }
}