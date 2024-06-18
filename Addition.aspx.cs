using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumablesPortal
{
    public partial class Addition : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                    {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Table_1(item_name,item_make,item_model,item_quantity) values(@item_name,@item_make,@item_model)", con);

            catch (Exception ex)
            {

            }
           
        }
    }
}