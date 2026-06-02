using System;

namespace EngineeringMasterclass.Domain.Models {
    public class Submission {

        public int SubmissionId {get; set;}

        public int StudentId {get; set;}
        public int AssignmentId {get; set;}

        public string Content {get; set;} = string.Empty;
        public double? Grade {get; set;}
        public DateTime SubmittedAt {get; set;}
        public string Feedback {get; set;} = string.Empty;


        public Student Student {get; set;} = null!;
        public Assignment Assignment {get; set;} = null!;

    }
}