using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZamianaUnitermu
{
    class Database
    {
        private static String _connectionString = "Data Source=MSI;Initial Catalog=MASI;User ID=sa;Password=sa";
        private SqlConnection _connection;

        public Database()
        {
            _connection = new SqlConnection(_connectionString);
        }
        public void Connect()
        {
            try
            {
                _connection.Open();
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataRowCollection ExecuteQuery(string query)
        {
            DataTable tab = new DataTable();

            this.Connect();

            if (_connection.State == ConnectionState.Open)
            {
                SqlDataAdapter ad = new SqlDataAdapter(query, _connection);

                ad.Fill(tab);
            }
            else
            {
                MessageBox.Show("Nie można połączyć się z bazą daych");
            }

            this.Disconnect();

            return tab.Rows;
        }
    }
}
