using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CayXanhAPI.BAL.Interfaces
{

    public class ConnectDatabase : IConnectDatabase
    {
        //protected IDbConnection conn;
        //public ConnectDatabase()
        //{
        //    string connectionString = @"Data Source=10.238.200.5\SQLV2016;Initial Catalog=CayXanhDoThi;Persist Security Info=True;User ID=cayxanhdothi";
        //    conn = new SqlConnection(connectionString);

        //}
        public SqlConnection ConnectDataBase()
        {
            try
            {
                var conn = new SqlConnection
                {
                    ConnectionString = @"Data Source=10.238.200.5\SQLV2016;Initial Catalog=CayXanhDoThi;Persist Security Info=True;User ID=cayxanhdothi;Password=B1nhB0t#"
                };

                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
