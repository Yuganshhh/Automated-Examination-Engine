namespace EngineeringMasterclass.Api.Dtos
{
    public class SubmissionCreateDto
    {
        // We only allow the student to submit these three properties!
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}