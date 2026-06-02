using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringMasterclass.Domain.Interfaces;
using EngineeringMasterclass.Domain.Models;

namespace EngineeringMasterclass.Services.Graders
{
    public class QuizGraders : IGradingStrategy
    {
        public string AssignmentType => "Quiz";

        public async Task GradeAsync(Submission submission)
        {
            await Task.Delay(50);

            submission.Grade = 87.8;
            submission.Feedback = "You did great in the Quiz";
        }

    }
}