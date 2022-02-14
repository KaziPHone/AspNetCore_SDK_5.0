using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using FluentMigrator.Runner;
using MetricsAgent.DAL.Jobs.Configs;
using MetricsAgent.DAL.Jobs.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace MetricsAgent.DAL.Services
{
    public static class Services
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });

            services.AddSingleton<ConnectionDb>();
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotnetMetricsRepository, DotnetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSingleton<NetworkMetricsRepository, NetworkMetricsRepository>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            var connectionDb = new ConnectionDb();
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // добавляем поддержку SQLite
                    .AddSQLite()
                    // устанавливаем строку подключения
                    .WithGlobalConnectionString(connectionDb.ConnectionStringSQLLite())
                    // подсказываем где искать классы с миграциями
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());
            
            // ДОбавляем сервисы
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // добавляем нашу задачу
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton<RamMetricJob>();
            services.AddSingleton<HddMetricJob>();
            services.AddSingleton<DotnetMetricJob>();
            //services.AddSingleton<NetworkMetricJob>();

            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotnetMetricJob),
                cronExpression: "0/5 * * * * ?"));
            /*services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: "0/5 * * * * ?"));*/

            services.AddHostedService<QuartzHostedService>();
            
        }
    }
}
