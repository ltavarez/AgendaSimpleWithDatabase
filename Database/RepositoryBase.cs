using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RepositoryBase
    {

        private readonly SqlConnection _connection;

        public RepositoryBase(SqlConnection connection)
        {
            _connection = connection;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public bool ExecuteDml(SqlCommand query)
        {
            try
            {
                _connection.Open();

                query.ExecuteNonQuery();

                _connection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public DataTable LoadData(SqlDataAdapter query)
        {
            try
            {
                DataTable data = new DataTable();
                _connection.Open();

                query.Fill(data);

                _connection.Close();


                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

    }
}
