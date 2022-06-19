using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library_Manager.DBLayer;
using System.Windows;

namespace Library_Manager.BSLayer
{
    class BLAuthor
    {
        DBMain db = null!;
        private string tableName = "Authors";
        public BLAuthor()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Author_id, string Author_name, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Author_id}', N'{Author_name}')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Author_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Author_id='{Author_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Author_id, string Author_name, ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Author_name=N'{Author_name}' " +
                $"Where Author_id='{Author_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Author_id, string Author_name, ref string err)
        {

            string sqlString = $"select * from {tableName} Where     ";
            if (Author_id != "")
                sqlString += $"Author_id = '{Author_id}' and ";
            if (Author_name != "")
                sqlString += $"Author_name = N'{Author_name}' and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}