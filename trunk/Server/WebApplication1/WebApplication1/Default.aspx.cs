using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=IAN-MAC\SQLEXPRESS;Initial Catalog=readings;Integrated Security=True;Pooling=False");
            sqlConnection.Open();

            SqlCommand sqlCmd = new SqlCommand("SELECT Data FROM Data WITH (NOLOCK)",sqlConnection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            string response = "[";
            while (reader.Read())
            {
                response = response + reader.GetValue(0).ToString() + ",";
            }
            response = response + "]";
            Response.Write(response);
            Response.End();
        }
    }
}