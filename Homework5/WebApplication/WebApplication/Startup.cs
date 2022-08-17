using ClientService.Context;
using ClientService.DepartmentCommands;
using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations;
using ClientService.GradeCommands;
using ClientService.GradeCommands.Interfaces;
using ClientService.GradeRequests;
using ClientService.GradeValidations;
using ClientService.MentorCommands;
using ClientService.MentorCommands.Interfaces;
using ClientService.MentorRequests;
using ClientService.MentorValidations;
using ClientService.Requests;
using ClientService.StudentCommands;
using ClientService.StudentCommands.Interfaces;
using ClientService.StudentRequests;
using ClientService.StudentValidations;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbConnStr = Configuration.GetConnectionString("SQLConnectionString");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(dbConnStr);
            });

            services.AddControllers();

            services.AddTransient<IValidator<CreateStudentRequest>, CreateStudentRequestValidator>();
            services.AddTransient<IValidator<GetStudentRequest>, GetStudentRequestValidator>();
            services.AddTransient<IValidator<UpdateStudentRequest>, UpdateStudentRequestValidator>();
            services.AddTransient<IValidator<FindStudentRequest>, FindStudentRequestValidator>();

            services.AddTransient<IValidator<CreateMentorRequest>, CreateMentorRequestValidator>();
            services.AddTransient<IValidator<GetMentorRequest>, GetMentorRequestValidator>();
            services.AddTransient<IValidator<UpdateMentorRequest>, UpdateMentorRequestValidator>();
            services.AddTransient<IValidator<FindMentorRequest>, FindMentorRequestValidator>();

            services.AddTransient<IValidator<CreateDepartmentRequest>, CreateDepartmentRequestValidator>();
            services.AddTransient<IValidator<GetDepartmentRequest>, GetDepartmentRequestValidator>();
            services.AddTransient<IValidator<UpdateDepartmentRequest>, UpdateDepartmentRequestValidator>();
            services.AddTransient<IValidator<FindDepartmentRequest>, FindDepartmentRequestValidator>();

            services.AddTransient<IValidator<CreateGradeRequest>, CreateGradeRequestValidator>();
            services.AddTransient<IValidator<GetGradeRequest>, GetGradeRequestValidator>();
            services.AddTransient<IValidator<UpdateGradeRequest>, UpdateGradeRequestValidator>();
            services.AddTransient<IValidator<FindGradeRequest>, FindGradeRequestValidator>();

            services.AddTransient<ICreateStudentCommand, CreateStudentCommand>();
            services.AddTransient<IGetStudentCommand, GetStudentCommand>();
            services.AddTransient<IUpdateStudentCommand, UpdateStudentCommand>();
            services.AddTransient<IFindStudentCommand, FindStudentCommand>();

            services.AddTransient<ICreateMentorCommand, CreateMentorCommand>();
            services.AddTransient<IGetMentorCommand, GetMentorCommand>();
            services.AddTransient<IUpdateMentorCommand, UpdateMentorCommand>();
            services.AddTransient<IFindMentorCommand, FindMentorCommand>();

            services.AddTransient<ICreateDepartmentCommand, CreateDepartmentCommand>();
            services.AddTransient<IGetDepartmentCommand, GetDepartmentCommand>();
            services.AddTransient<IUpdateDepartmentCommand, UpdateDepartmentCommand>();
            services.AddTransient<IFindDepartmentCommand, FindDepartmentCommand>();

            services.AddTransient<ICreateGradeCommand, CreateGradeCommand>();
            services.AddTransient<IGetGradeCommand, GetGradeCommand>();
            services.AddTransient<IUpdateGradeCommand, UpdateGradeCommand>();
            services.AddTransient<IFindGradeCommand, FindGradeCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var dbContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();

            dbContext.Database.Migrate();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
