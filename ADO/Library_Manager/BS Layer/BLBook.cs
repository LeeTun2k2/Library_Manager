using System.Data;
using Library_Manager.DBLayer;

namespace Library_Manager.BSLayer
{
    class BLBook
    {
        DBMain db = null!;
        private string tableName = "Books";
        public BLBook()
        {
            db = new DBMain();
        }
        public DataSet Get()
        {
            return db.ExecuteQueryDataSet($"select * from {tableName}", CommandType.Text);
        }
        public bool Add(string Book_id, string Title, string Category, string Author_id,
            string Publisher_id, string YearOfPublication, string Price, string Quantity, ref string err)
        {
            string sqlString = $"Insert Into {tableName} Values('{Book_id}', N'{Title}', N'{Category}', " +
                $"'{Author_id}', '{Publisher_id}', {YearOfPublication},{Price}, {Quantity} )";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool Delete(string Book_id, ref string err)
        {
            string sqlString = $"Delete From {tableName} Where Book_id='{Book_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        
        public bool Update(string Book_id, string Title, string Category, string Author_id,
            string Publisher_id, string YearOfPublication, string Price, string Quantity, ref string err)
        {
            string sqlString = $"Update {tableName} Set " +
                $"Title=N'{Title}', Category=N'{Category}', " +
                $"Author_id='{Author_id}', Publisher_id='{Publisher_id}', " +
                $"YearOfPublication = {YearOfPublication}, Price={Price}, Quantity={Quantity} " +
                $"Where Book_id='{Book_id}'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public DataSet Search(string Book_id, string Title, string Category, string Author_id,
            string Publisher_id, string YearOfPublication, string Price, string Quantity, ref string err)
        {

            string sqlString = $"select * from {tableName} Where    ";
            if (Book_id != "")
                sqlString += $"Book_id = '{Book_id}' and ";
            if (Title != "")
                sqlString += $"Title = N'{Title}' and ";
            if (Category != "")
                sqlString += $"Category = N'{Category}' and ";
            if (Author_id != "")
                sqlString += $"Author_id = '{Author_id}' and ";
            if (Publisher_id != "")
                sqlString += $"Publisher_id = '{Publisher_id}' and ";
            if (YearOfPublication != "")
                sqlString += $"YearOfPublication = {YearOfPublication} and ";
            if (Price != "")
                sqlString += $"Price = {Price} and ";
            if (Quantity != "")
                sqlString += $"Quantity = {Quantity} and ";
            sqlString = sqlString.Substring(0, sqlString.Length - 4);
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
    }
}