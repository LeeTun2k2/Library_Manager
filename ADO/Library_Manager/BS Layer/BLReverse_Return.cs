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
    class BLReverse_Return
    {
        DBMain db = null!;
        private string tableName = "Reverse_Return";
        public BLReverse_Return()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Reg_id, string Reader_id, string Book_id, string ReserveDate,
            string DueDate, string ReturnDate, string ReserveStaff_id, string ReturnStaff_id, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Reg_id}', '{Reader_id}', '{Book_id}', " +
                $"'{ReserveDate}', '{DueDate}', '{ReturnDate}', " +
                $"'{ReserveStaff_id}', '{ReturnStaff_id}')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Reg_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Reg_id='{Reg_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Reg_id, string Reader_id, string Book_id, string ReserveDate,
            string DueDate, string ReturnDate, string ReserveStaff_id, string ReturnStaff_id, ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Reader_id='{Reader_id}', Book_id='{Book_id}', " +
                $"ReserveDate='{ReserveDate}', DueDate='{DueDate}', " +
                $"ReturnDate = '{ReturnDate}', ReserveStaff_id='{ReserveStaff_id}', ReturnStaff_id='{ReturnStaff_id}'" +
                $" Where Reg_id='{Reg_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Reg_id, string Reader_id, string Book_id, string ReserveDate,
            string DueDate, string ReturnDate, string ReserveStaff_id, string ReturnStaff_id, ref string err)
        {

            string sqlString = $"select * from {tableName} Where    ";
            if (Reg_id != "")
                sqlString += $"Reg_id = '{Reg_id}' and ";
            if (Reader_id != "")
                sqlString += $"Reader_id = '{Reader_id}' and ";
            if (Book_id != "")
                sqlString += $"Book_id = '{Book_id}' and ";
            if (ReserveDate != "")
                sqlString += $"ReserveDate = '{ReserveDate}' and ";
            if (DueDate != "")
                sqlString += $"DueDate = '{DueDate}' and ";
            if (ReturnDate != "")
                sqlString += $"ReturnDate = '{ReturnDate}' and ";
            if (ReserveStaff_id != "")
                sqlString += $"ReserveStaff_id = '{ReserveStaff_id}' and ";
            if (ReturnStaff_id != "")
                sqlString += $"ReturnStaff_id = '{ReturnStaff_id}' and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}