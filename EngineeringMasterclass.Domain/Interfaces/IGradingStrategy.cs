using EngineeringMasterclass.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngineeringMasterclass.Domain.Interfaces
{
    public interface IGradingStrategy
    {
        string AssignmentType {get;}

        Task GradeAsync(Submission submission);
    }
}