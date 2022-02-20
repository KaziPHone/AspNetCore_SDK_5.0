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
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private readonly string _connectionString;

        public HddMetricsRepository(ConnectionDb connectionDb)
        {
            _connectionString = connectionDb.ConnectionStringSQLLite();
        }

        public void Create(HddMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(HddMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("UPDATE hddmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }

        public IList<HddMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<HddMetric>("SELECT Id, Time, Value FROM hddmetrics").ToList();
            }
        }

        public IList<HddMetric> GetAllBetweenTime(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                var query = String.Format("SELECT id, value, time FROM cpumetrics WHERE time>{0} AND time<{1}", fromTime.TotalSeconds, toTime.TotalSeconds);
                return connection.Query<HddMetric>(query).ToList();
            }
        }

        public HddMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, Time, Value FROM hddmetrics WHERE id = @id",
                new
                {
                    id = id
                });
            }
        }
    }
}
