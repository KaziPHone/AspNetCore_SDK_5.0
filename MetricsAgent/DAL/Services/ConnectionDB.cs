namespace MetricsAgent.DAL.Services
{
    public class ConnectionDB
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// SQL Lite
        /// </summary>
        /// <returns>"DataSource = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100;"</returns>
        public string ConnectionStringSQLLite()
        {
            return "DataSource = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        }


    }
}
