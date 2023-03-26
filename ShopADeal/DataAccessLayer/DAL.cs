using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace ShopADeal.DataConnection
{
    public class DAL
    {
        public DAL()
        {
        }
        public SqlConnection sqlConnection()
        {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["ShopADeal.Properties.Settings.dbshopadealConnectionString"].ConnectionString);
        }
        public SqlDataAdapter SQLAdapterSelectFrom(string columns, string table)
        {
            return new SqlDataAdapter($"select {columns} from {table}", new DAL().sqlConnection());
        }
        public SqlDataAdapter SQLAdapterSelectFromWhere(string columns, string table, string where)
        {
            return new SqlDataAdapter($"select {columns} from {table} where {where}", new DAL().sqlConnection());
        }
        public void SQLAdapterInsert(string table, string columns, string values)
        {
            new SqlCommand($"insert into {table} ({columns}) values ({values})", new DAL().sqlConnection());
        }
    }
}
