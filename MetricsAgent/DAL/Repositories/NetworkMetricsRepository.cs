using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Services;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private readonly string _connectionString;

        public NetworkMetricsRepository(ConnectionDB connectionDb)
        {
            _connectionString = connectionDb.ConnectionStringSQLLite();
        }

        public void Create(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                connection.Execute("UPDATE networkmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.TotalSeconds,
                    id = item.Id
                });
            }
        }

        public IList<NetworkMetric> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM networkmetrics").ToList();
            }
        }

        public NetworkMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            {
                return connection.QuerySingle<NetworkMetric>("SELECT Id, Time, Value FROM networkmetrics WHERE id = @id",
                new
                {
                    id = id
                });
            }
        }
    }
}
