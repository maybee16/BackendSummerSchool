using ClientService.DepartmentCommands;
using ClientService.DepartmentCommands.Interfaces;
using ClientService.DepartmentRequests;
using ClientService.DepartmentValidations;
using ClientService.GradeCommands;
using ClientService.GradeCommands.Interfaces;
using ClientService.GradeValidations;
using ClientService.MentorCommands;
using ClientService.MentorCommands.Interfaces;
using ClientService.MentorValidations;
using ClientService.StudentCommands;
using ClientService.StudentCommands.Interfaces;
using ClientService.StudentValidations;
using FluentValidation;
using GradeRequests;
using MassTransit;
using MentorRequests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentRequests;
using System;

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

            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                });

                mt.AddRequestClient<CreateStudentRequest>(new Uri("rabbitmq://localhost/createStudent"));
                mt.AddRequestClient<GetStudentRequest>(new Uri("rabbitmq://localhost/getStudent"));
                mt.AddRequestClient<UpdateStudentRequest>(new Uri("rabbitmq://localhost/updateStudent"));
                mt.AddRequestClient<FindStudentRequest>(new Uri("rabbitmq://localhost/findStudent"));

                mt.AddRequestClient<CreateMentorRequest>(new Uri("rabbitmq://localhost/createMentor"));
                mt.AddRequestClient<GetMentorRequest>(new Uri("rabbitmq://localhost/getMentor"));
                mt.AddRequestClient<UpdateMentorRequest>(new Uri("rabbitmq://localhost/updateMentor"));
                mt.AddRequestClient<FindMentorRequest>(new Uri("rabbitmq://localhost/findMentor"));

                mt.AddRequestClient<CreateGradeRequest>(new Uri("rabbitmq://localhost/createGrade"));
                mt.AddRequestClient<GetGradeRequest>(new Uri("rabbitmq://localhost/getGrade"));
                mt.AddRequestClient<UpdateGradeRequest>(new Uri("rabbitmq://localhost/updateGrade"));
                mt.AddRequestClient<FindGradeRequest>(new Uri("rabbitmq://localhost/findGrade"));

                mt.AddRequestClient<CreateDepartmentRequest>(new Uri("rabbitmq://localhost/createDepartment"));
                mt.AddRequestClient<GetDepartmentRequest>(new Uri("rabbitmq://localhost/getDepartment"));
                mt.AddRequestClient<UpdateDepartmentRequest>(new Uri("rabbitmq://localhost/updateDepartment"));
                mt.AddRequestClient<FindDepartmentRequest>(new Uri("rabbitmq://localhost/findDepartment"));
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
