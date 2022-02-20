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
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private readonly string _connectionString;

        public RamMetricsRepository(ConnectionDb connectionDb)
        {
            _connectionString = connectionDb.ConnectionStringSQLLite();
        }

        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(RamMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("UPDATE rammetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics").ToList();
            }
        }

        public IList<RamMetric> GetAllBetweenTime(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                var query = String.Format("SELECT id, value, time FROM cpumetrics WHERE time>{0} AND time<{1}", fromTime.TotalSeconds, toTime.TotalSeconds);
                return connection.Query<RamMetric>(query).ToList();
            }
        }

        public RamMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.QuerySingle<RamMetric>("SELECT Id, Time, Value FROM rammetrics WHERE id = @id",
                new
                {
                    id = id
                });
            }
        }
    }
}
