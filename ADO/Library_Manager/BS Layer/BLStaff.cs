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
    class BLStaff
    {
        DBMain db = null!;
        private string tableName = "staff";
        public BLStaff()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Staff_id, string Staff_name, string Birthday, string Sex, 
            string Email, string Phone_no, string Addr, string startDate ,string Salary, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Staff_id}', N'{Staff_name}'," +
                $"'{Birthday}', N'{Sex}', '{Email}', '{Phone_no}', N'{Addr}', '{startDate}' ,'{Salary}')";
            MessageBox.Show(sqlString);
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Staff_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Staff_id='{Staff_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Staff_id, string Staff_name, string Birthday, string Sex,
            string Email, string Phone_no, string Addr, string Salary, ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Staff_name=N'{Staff_name}', " +
                $"Birthday='{Birthday}'," +
                $"Sex=N'{Sex}'," +
                $"Email='{Email}'," +
                $"Phone_no='{Phone_no}'," +
                $"Addr=N'{Addr}'," +
                $"Salary={Salary} " +
                $"Where Staff_id='{Staff_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Staff_id, string Staff_name, string Birthday, string Sex,
            string Email, string Phone_no, string Addr, string Salary, ref string err)
        {
            string sqlString = $"select * from {tableName} Where     ";
            if (Staff_id != "")
                sqlString += $"Staff_id = '{Staff_id}' and ";
            if (Staff_name != "")
                sqlString += $"Staff_name = N'{Staff_name}' and ";
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
            if (Salary != "")
                sqlString += $"Salary = '{Salary}' and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}