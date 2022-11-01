using Microsoft.Data.SqlClient;
using System.Data;

namespace CHK.Infrastructure
{
    public class ReadConnectionFactory : IDisposable
    {
        private readonly string _cs;
        private SqlConnection _connection;
        public ReadConnectionFactory(IConfiguration configuration)
        {
            _cs = configuration.GetConnectionString("cs");
        }

        public IDbConnection Create()
        {
            if(_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_cs);
                _connection.Open();
                return _connection;
            }

            return _connection;
            
        }

        public void Dispose()
        {
            if(_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
