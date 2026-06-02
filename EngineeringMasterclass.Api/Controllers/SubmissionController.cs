using EngineeringMasterclass.Api.Dtos;
using EngineeringMasterclass.Domain.Interfaces;
using EngineeringMasterclass.Domain.Models;
using EngineeringMasterclass.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EngineeringMasterclass.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionRepository _repository;
        private readonly GradingEngineService _gradingEngine;

        // 1. Dependency Injection
        public SubmissionsController(ISubmissionRepository repository, GradingEngineService gradingEngine)
        {
            _repository = repository;
            _gradingEngine = gradingEngine;
        }

        // 2. The HTTP POST Endpoint
        [HttpPost]
        public async Task<IActionResult> SubmitAssignment([FromBody] SubmissionCreateDto dto)
        {
            // 3. Map the DTO to the Domain Model securely
            var newSubmission = new Submission
            {
                StudentId = dto.StudentId,
                AssignmentId = dto.AssignmentId,
                Content = dto.Content,
                SubmittedAt = DateTime.UtcNow
                // Grade and Feedback remain null!
            };

            // 4. Save the ungraded submission to the database
            var createdSubmission = await _repository.CreateSubmissionAsync(newSubmission);
            await _repository.SaveChangesAsync();

            // 5. Trigger the High-Concurrency Polymorphic Grading Engine
            await _gradingEngine.ProcessSubmissionAsync(createdSubmission.SubmissionId);

            // 6. Fetch the newly graded submission to show the user
            var gradedSubmission = await _repository.GetSubmissionByIdAsync(createdSubmission.SubmissionId);

            // 7. Return HTTP 200 OK with the graded result
            return Ok(gradedSubmission);
        }
    }
}