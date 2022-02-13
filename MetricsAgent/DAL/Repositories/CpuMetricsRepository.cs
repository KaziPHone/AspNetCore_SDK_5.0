using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Services;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using MetricsAgent.DAL.Handlers;

namespace MetricsAgent.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private readonly string _connectionString;

        public CpuMetricsRepository(ConnectionDb connectionDb)
        {
            _connectionString = connectionDb.ConnectionStringSQLLite();
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(CpuMetric item)
        {

            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds
                });
            }

        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(CpuMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }

        public IList<CpuMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
            }
        }

        public CpuMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id = @id",
                new 
                { 
                    id = id 
                });
            }
        }

        public IList<CpuMetric> GetAllBetweenTime(TimeSpan fromTime, TimeSpan toTime)
        {
            var fromT = fromTime.TotalSeconds;
            var tot = toTime.TotalSeconds;
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<CpuMetric>("SELECT id, value, time FROM cpumetrics WHERE time>@fromT AND time<@toT").ToList();
            }
        }

    }
}
