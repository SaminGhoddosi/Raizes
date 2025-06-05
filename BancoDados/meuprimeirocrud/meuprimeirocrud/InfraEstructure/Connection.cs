using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.InfraEstructure
{
    public class Connection
    {
        protected string connectionString = "Server=localhost;Database=raizes;User=root;Password=root;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
