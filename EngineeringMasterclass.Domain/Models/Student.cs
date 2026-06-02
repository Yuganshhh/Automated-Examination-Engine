using System;

namespace EngineeringMasterclass.Domain.Models;

public class Student
{
    public int StudentId {get; set;}
    
    public string Email {get; set;} = string.Empty;
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public DateTime EnrollmentDate {get; set;}

    public ICollection<Submission> Submissions {get; set;} = new List<Submission>();
}

