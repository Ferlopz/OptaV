using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Repository.Conexion
{
    public class DbConection
    {
        private string connectionString;
        public DbConection(string _connectionSring) 
        { 
            this.connectionString = _connectionSring;
        }

        public IDbConnection dbConnection()
        {

            try
            {
                IDbConnection conexion = new Npgsql.NpgsqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.Message);
            }
            
        }
    }
}
