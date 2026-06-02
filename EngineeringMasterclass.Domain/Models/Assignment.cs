using System;

namespace EngineeringMasterclass.Domain.Models {
    public class Assignment {

        public int AssignmentId {get; set;}

        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public DateTime DueDate {get; set;}
        public string AssignmentType {get; set;} = string.Empty;
        
        public ICollection<Submission> Submissions {get; set;} = new List<Submission>();

    }
}