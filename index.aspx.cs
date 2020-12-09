using System;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string status = "";
            string connStr = "SERVER = mssql-16492-0.cloudclusters.net,16514; DATABASE = Pierwsza; USER ID = Mateusz; PASSWORD = Czapka987";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [AccountID], [Status] FROM [Aws] ;");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            string AccountID = "";
            string Status = "";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AccountID += reader["AccountID"].ToString();
                Status += reader["Status"].ToString();;
                AccountID += "<br>";
                Status += "<br>";
            }

            lbl_test.Text = AccountID;
            lbl_test1.Text = Status;
            conn.Close();
        }
    }
}