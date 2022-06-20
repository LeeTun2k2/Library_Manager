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
    class BLPublisher
    {
        DBMain db = null!;
        private string tableName = "Publishers";
        public BLPublisher()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Publisher_id, string Publisher_name, 
            string Email, string Phone_no, string Addr, ref string err)
        {
            if (Email.Contains('@'))
            {
                string sqlString = $"Insert Into {tableName} Values('{Publisher_id}', N'{Publisher_name}', " +
                $"'{Email}', '{Phone_no}', N'{Addr}')";
                return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            }
            MessageBox.Show("Email không hợp lệ");
            return false;
        }

        public bool Delete(string Publisher_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Publisher_id='{Publisher_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Publisher_id, string Publisher_name,
            string Email, string Phone_no, string Addr, ref string err)
        {
            if (Email.Contains('@'))
            {
                string sqlString = $"Update {tableName} Set " +
                $"Publisher_name=N'{Publisher_name}', " +
                $"Email='{Email}'," +
                $"Phone_no='{Phone_no}'," +
                $"Addr=N'{Addr}' " +
                $"Where Publisher_id='{Publisher_id}'";
                return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            }
            MessageBox.Show("Email không hợp lệ");
            return false;
        }

        public DataSet Search(string Publisher_id, string Publisher_name,
            string Email, string Phone_no, string Addr, ref string err)
        {
            string sqlString = $"select * from {tableName} Where     ";
            if (Publisher_id != "")
                sqlString += $"Publisher_id = '{Publisher_id}' and ";
            if (Publisher_name != "")
                sqlString += $"Publisher_name = N'{Publisher_name}' and ";
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