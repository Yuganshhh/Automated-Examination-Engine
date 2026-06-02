using EngineeringMasterclass.Api.Middleware;
using EngineeringMasterclass.Dal;
using EngineeringMasterclass.Dal.Repositories;
using EngineeringMasterclass.Domain.Interfaces;
using EngineeringMasterclass.Services;
using EngineeringMasterclass.Services.Graders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();


builder.Services.AddScoped<GradingEngineService>();


builder.Services.AddScoped<IGradingStrategy, QuizGrader>();
builder.Services.AddScoped<IGradingStrategy, CodeGrader>();


var app = builder.Build();


app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();