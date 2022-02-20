using System;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Services;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL.Repositories
{
    public class DotnetMetricsRepository : IDotnetMetricsRepository
    {
        private readonly string _connectionString;

        public DotnetMetricsRepository(ConnectionDb connectionDb)
        {
            _connectionString = connectionDb.ConnectionStringSQLLite();
        }

        public void Create(DotnetMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM dotnetmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(DotnetMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("UPDATE dotnetmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }

        public IList<DotnetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<DotnetMetric>("SELECT Id, Time, Value FROM dotnetmetrics").ToList();
            }
        }
        
        public DotnetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.QuerySingle<DotnetMetric>("SELECT Id, Time, Value FROM dotnetmetrics WHERE id = @id",
                new
                {
                    id = id
                });
            }
        }
        
        public IList<DotnetMetric> GetAllBetweenTime(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                var query = String.Format("SELECT id, value, time FROM cpumetrics WHERE time>{0} AND time<{1}", fromTime.TotalSeconds, toTime.TotalSeconds);
                return connection.Query<DotnetMetric>(query).ToList();
            }
        }
    }
}
