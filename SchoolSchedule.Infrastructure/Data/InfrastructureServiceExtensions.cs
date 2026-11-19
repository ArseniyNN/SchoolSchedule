using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSchedule.Core.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Services;

namespace SchoolSchedule.Infrastructure.Data
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString(ConnectionNames.Default)));

            services.AddScoped(typeof(IRepository<>) , typeof(Repository<>));
            services.AddScoped<IClassService , ClassService>();
            services.AddScoped<ICurriculumItemService, CurriculumItemService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IScheduleGenerator, ScheduleGeneratorService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISubjectService, SubjectService>();
            return services;
        }
    }
}
