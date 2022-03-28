using System;
using System.Data;
using System.Data.SqlClient;
using SGCE.Shared;

namespace SGCE.Infra.DataContexts
{
    public class SgceDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public SgceDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}