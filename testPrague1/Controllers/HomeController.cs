using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testPrague1.Controllers
{
    public class HomeController : Controller
    {
        public class JsonUserName
        {
            public string username { get; set; }
        }

        public ActionResult Index()
        {
            SqlConnection lSQLConn = null;
            SqlCommand lSQLCmd = new SqlCommand();
            //Declare a DataAdapter and a DataSet
            SqlDataAdapter lDA = new SqlDataAdapter();
            DataSet lDS = new DataSet();

            //...Execution section
            string connStr = "Data Source=(LocalDb)\\MSSQLLocalDB ;Initial Catalog=aspnet-testPrague1-20170203122002;Integrated Security=True";
            lSQLConn = new SqlConnection(connStr);
            lSQLConn.Open();
            //The CommandType must be StoredProcedure if we are using an ExecuteScalar
            lSQLCmd.CommandType = CommandType.StoredProcedure;
            lSQLCmd.CommandText = "GetUserName";
            lSQLCmd.Connection = lSQLConn;
            //Fill the DataAdapter with a SelectCommand
            lDA.SelectCommand = lSQLCmd;
            lDA.Fill(lDS);
            string str = "";
            List<JsonUserName> Usernames = new List<JsonUserName>();
            using (SqlDataReader reader = lSQLCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usernames.Add(new JsonUserName { username = reader.GetString(0).ToString() });
                    }
                }
            }
            string json = "";
            //foreach (string username in Usernames) {
            json = JsonConvert.SerializeObject(Usernames);
            //}
            ViewBag.usernames = json;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}