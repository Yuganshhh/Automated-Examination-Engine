using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringMasterclass.Domain.Interfaces;
using EngineeringMasterclass.Domain.Models;

namespace EngineeringMasterclass.Services.Graders
{
    public class CodeGraders : IGradingStrategy
    {
        public string AssignmentType => "Code";
        public async Task GradeAsync(Submission submission)
        {
            await Task.Delay(200);

            submission.Grade = 67.9;
            submission.Feedback = "You did okay in the code";
        }
    }
}