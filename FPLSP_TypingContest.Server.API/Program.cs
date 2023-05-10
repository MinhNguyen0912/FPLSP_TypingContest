using AutoMapper.Extensions.ExpressionMapping;
using FPLSP_TypingContest.Server.BLL;
using FPLSP_TypingContest.Server.BLL.Services.Implements;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

// Add services to the container.
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IUserRoleServices, UserRoleServices>();

builder.Services.AddTransient<ITrainingFacilityServices, TrainingFacilityServices>();
builder.Services.AddTransient<IOrganizerServices, OrganizerServices>();
builder.Services.AddTransient<IParticipantServices, ParticipantServices>();

builder.Services.AddTransient<IContestService, ContestService>();
builder.Services.AddTransient<IRoundService, RoundService>();

builder.Services.AddTransient<ITextTemplateServices, TextTemplateServices>();
builder.Services.AddTransient<ILevelServices, LevelServices>();

builder.Services.AddTransient<IContentForRoundServices, ContentForRoundServices>();
builder.Services.AddTransient<IScoreOfParticipantServices, ScoreOfParticipantServices>();

builder.Services.AddTransient<IRatingOfRoundServices, RatingOfRoundServices>();

builder.Services.AddAutoMapper(config =>
{
    config.AddExpressionMapping();
}, Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();