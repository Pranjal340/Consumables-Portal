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
    public partial class DateQty : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        DataTable dt;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "SELECT * FROM date_qty ";
                dt = new DataTable();
                con.Open();
                da = new SqlDataAdapter(query, this.con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if (DateTime.TryParse(txtStartDate.Text, out startDate) && DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                DataTable filteredData = GetFilteredData(startDate, endDate);
                GridView1.DataSource = filteredData;
                GridView1.DataBind();
            }
            else
            {
                lblError.Text = "Please enter valid dates";
                lblError.Visible = true;
            }
        }

        public DataTable GetFilteredData(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT item_name,item_make,item_model,today_date,today_qty FROM date_qty WHERE today_date BETWEEN @startDate AND @endDate ";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}