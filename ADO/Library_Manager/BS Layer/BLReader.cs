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
    class BLReader
    {
        DBMain db = null!;
        private string tableName = "Readers";
        public BLReader()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Reader_id, string Reader_name, string Birthday, string Sex, 
            string Email, string Phone_no, string Addr, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Reader_id}', N'{Reader_name}'," +
                $"'{Birthday}', N'{Sex}', '{Email}', '{Phone_no}', N'{Addr}')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Reader_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Reader_id='{Reader_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Reader_id, string Reader_name, string Birthday, string Sex,
            string Email, string Phone_no, string Addr, ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Reader_name=N'{Reader_name}', " +
                $"Birthday='{Birthday}'," +
                $"Sex=N'{Sex}'," +
                $"Email='{Email}'," +
                $"Phone_no='{Phone_no}'," +
                $"Addr=N'{Addr}' " +
                $"Where Reader_id='{Reader_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Reader_id, string Reader_name, string Birthday, string Sex,
            string Email, string Phone_no, string Addr, ref string err)
        {
            string sqlString = $"select * from {tableName} Where     ";
            if (Reader_id != "")
                sqlString += $"Reader_id = '{Reader_id}' and ";
            if (Reader_name != "")
                sqlString += $"Reader_name = N'{Reader_name}' and ";
            if (Birthday != "")
                sqlString += $"Birthday = '{Birthday}' and ";
            if (Sex != "")
                sqlString += $"Sex = N'{Sex}' and ";
            if (Email != "")
                sqlString += $"Email = '{Email}' and ";
            if (Phone_no != "")
                sqlString += $"Phone_no = '{Phone_no}' and ";
            if (Addr != "")
                sqlString += $"Addr = N'{Addr}' and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}