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
    class BLAuthenticationSystem
    {
        DBMain db = null!;
        private string tableName = "AuthenticationSystem";
        public BLAuthenticationSystem()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Staff_id, string Username, string Pass_word, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Staff_id}', '{Username}', '{Pass_word}')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Staff_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Staff_id='{Staff_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Username, string Pass_word, string Re_Password,ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Pass_word='{Re_Password}' " +
                $"Where Username='{Username}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Staff_id, string Username, string Pass_word, ref string err)
        {
            string sqlString = $"select * from {tableName} Where     ";
            if (Staff_id != "")
                sqlString += $"Staff_id = '{Staff_id}' and ";
            if (Username != "")
                sqlString += $"Username = '{Username}' and ";
            if (Pass_word != "")
                sqlString += $"Pass_word = '{Pass_word}' and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}