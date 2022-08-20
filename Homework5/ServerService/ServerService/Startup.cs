using ClientService.Context;
using EF.Data;
using EF.Data.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerService.DepartmentConsumers;
using ServerService.GradeConsumers;
using ServerService.Mappers;
using ServerService.Mappers.Interfaces;
using ServerService.MentorConsumers;
using ServerService.StudentConsumers;

namespace ServerService
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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServerService", Version = "v1" });
            //});

            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<IMentorsRepository, MentorsRepository>();
            services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
            services.AddTransient<IGradesRepository, GradesRepository>();

            services.AddTransient<IStudentMapper, StudentMapper>();
            services.AddTransient<IMentorMapper, MentorMapper>();
            services.AddTransient<IDepartmentMapper, DepartmentMapper>();
            services.AddTransient<IGradeMapper, GradeMapper>();

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<CreateStudentConsumer>();
                mt.AddConsumer<GetStudentConsumer>();
                mt.AddConsumer<UpdateStudentConsumer>();
                mt.AddConsumer<FindStudentConsumer>();

                mt.AddConsumer<CreateMentorConsumer>();
                mt.AddConsumer<GetMentorConsumer>();
                mt.AddConsumer<UpdateMentorConsumer>();
                mt.AddConsumer<FindMentorConsumer>();

                mt.AddConsumer<CreateDepartmentConsumer>();
                mt.AddConsumer<GetDepartmentConsumer>();
                mt.AddConsumer<UpdateDepartmentConsumer>();
                mt.AddConsumer<FindDepartmentConsumer>();

                mt.AddConsumer<CreateGradeConsumer>();
                mt.AddConsumer<GetGradeConsumer>();
                mt.AddConsumer<UpdateGradeConsumer>();
                mt.AddConsumer<FindGradeConsumer>();

                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    config.ReceiveEndpoint("createStudent", ep => ep.ConfigureConsumer<CreateStudentConsumer>(context));
                    config.ReceiveEndpoint("getStudent", ep => ep.ConfigureConsumer<GetStudentConsumer>(context));
                    config.ReceiveEndpoint("updateStudent", ep => ep.ConfigureConsumer<UpdateStudentConsumer>(context));
                    config.ReceiveEndpoint("findStudent", ep => ep.ConfigureConsumer<FindStudentConsumer>(context));

                    config.ReceiveEndpoint("createMentor", ep => ep.ConfigureConsumer<CreateMentorConsumer>(context));
                    config.ReceiveEndpoint("getMentor", ep => ep.ConfigureConsumer<GetMentorConsumer>(context));
                    config.ReceiveEndpoint("updateMentor", ep => ep.ConfigureConsumer<UpdateMentorConsumer>(context));
                    config.ReceiveEndpoint("findMentor", ep => ep.ConfigureConsumer<FindMentorConsumer>(context));

                    config.ReceiveEndpoint("createDepartment", ep => ep.ConfigureConsumer<CreateDepartmentConsumer>(context));
                    config.ReceiveEndpoint("getDepartment", ep => ep.ConfigureConsumer<GetDepartmentConsumer>(context));
                    config.ReceiveEndpoint("updateDepartment", ep => ep.ConfigureConsumer<UpdateDepartmentConsumer>(context));
                    config.ReceiveEndpoint("findDepartment", ep => ep.ConfigureConsumer<FindDepartmentConsumer>(context));

                    config.ReceiveEndpoint("createGrade", ep => ep.ConfigureConsumer<CreateGradeConsumer>(context));
                    config.ReceiveEndpoint("getGrade", ep => ep.ConfigureConsumer<GetGradeConsumer>(context));
                    config.ReceiveEndpoint("updateGrade", ep => ep.ConfigureConsumer<UpdateGradeConsumer>(context));
                    config.ReceiveEndpoint("findGrade", ep => ep.ConfigureConsumer<FindGradeConsumer>(context));
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var dbContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();

            dbContext.Database.Migrate();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerService v1"));
            //}

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
