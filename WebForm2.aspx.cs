using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string kytu = Request.QueryString["w"];
            string sql = "SELECT * from Student where StudentId";
            if (kytu != "") {
                sql = "SELECT * from Student where StudentId = " + kytu;
            }else
            {
                sql = "SELECT * from Student where StudentId = 1";
            }
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            GridView2.DataSource = reader;
            GridView2.DataBind();

            conn.Close();
        }
    }
}