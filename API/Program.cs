
using API.ActionFilters;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.Profiles;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete;
using DataAcsessLayer.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Validation.GenericValidator;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
            });

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            builder.Services.AddScoped(typeof(ValidationFilter<>));
            builder.Services.AddScoped(typeof(IValidator<>), typeof(GenericValidator<>));

            // Servisləri əlavə et
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IExamService, ExamService>();

            // Repositoriesləri əlavə et
            builder.Services.AddScoped<ILessonRepository, LessonRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();




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
        }
    }
}
