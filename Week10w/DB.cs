using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Week10w
{
    public class DB
    {

        //const string CONNECT_STRING = @"Server=.\SQLEXPRESS;Database=SIS;Trusted_Connection=True;";
        //SqlConnection conn;

        //const string CONNECT_STRING = @"server=localhost;userid=root;database=personnel";
        //MySqlConnection conn;

        const string CONNECT_STRING = "DataSource=Personnel.db";
        SQLiteConnection conn;


        static DB _db;

        private DB()
        {
            //conn = new MySqlConnection(CONNECT_STRING);
            conn = new SQLiteConnection(CONNECT_STRING);
            conn.Open();
        }

        public static DB GetInstance()
        {
            if (_db == null)
                _db = new DB();
            return _db;
        }

        public List<Employee> Get(string name)
        {
            var ps = new  List<Employee>();
            var cmdString = string.Format(@"SELECT EmployeeID, Name, Position, Hourly_Payrate
                                                FROM Employee
                                                WHERE Name LIKE '%{0}%'", name);
            //var cmdString = "SELECT idEmployee, Name, Position, WageHourly FROM employee WHERE Name LIKE '%{0}%'",name;

            var cmd = new SQLiteCommand(cmdString, conn);

            SQLiteDataReader rd = cmd.ExecuteReader();

            //getordinal function is used to sort and perform action on a column by using case sensitive search
            //useless in loop because of searching same thing again and again over,so instead of using it in a loop assign it to an int
            //and call it throught that variable in a loop
            int employeeid = rd.GetOrdinal("EmployeeID");
            int empname = rd.GetOrdinal("Name");
            int empposition = rd.GetOrdinal("Position");
            int hourlyrate = rd.GetOrdinal("Hourly_Payrate");
            while (rd.Read())
                ps.Add(new Employee()
                {
                    idEmployee = rd.GetInt32(employeeid),
                    Name = rd.GetString(empname),
                    Position = rd.GetString(empposition),
                    WageHourly = rd.GetDouble(hourlyrate)
                    
                });
            rd.Close();

           // ps.Sort(new EmployeeSortByName()); Not sorting through name since we need to display it in primary key order

            return ps;
        }

    }
}
