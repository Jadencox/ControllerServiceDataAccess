using ControllerServiceDataAccess.DataAccess;
using ControllerServiceDataAccess.Extensions;
using ControllerServiceDataAccess.IServices;
using ControllerServiceDataAccess.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var Configuration = builder.Configuration;
builder.Services.AddDbContexts(Configuration);


#region ����
builder.Services.AddCors(cor =>
{
    cor.AddPolicy("Cors", policy =>
    {
        policy
        //.WithOrigins("https://localhost:15911", "http://0.0.0.0:3201")// ������վ���������
        .AllowAnyOrigin()// ��������վ���������
        .AllowAnyHeader()// ������������ͷ
                         //.AllowCredentials() //
        .AllowAnyMethod();// �����������󷽷�
    });
});
#endregion

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<StudentDataAccess>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
