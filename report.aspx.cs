using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumablesPortal
{
    public partial class report : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = GetData();
                dt = ReplaceNullWithNA(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            /*
            THIS CODE IS LESS OPTIMISED

            if(!IsPostBack)
            {
                //string query = "SELECT * FROM item i JOIN users u ON i.item_name = u.item_name AND i.item_make = u.item_make AND i.item_model = u.item_model ";
                string query = "SELECT i.item_name,i.item_make,i.item_model,i.total_qty,u.EID,u.process,u.edit_qty,u.edit_date,u.loc,u.cause FROM item i JOIN users u ON i.item_name = u.item_name AND i.item_make = u.item_make AND i.item_model = u.item_model ";
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, this.con);
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            */
        }

        public DataTable GetData()
        {
            //string query = "SELECT * FROM item i JOIN users u ON i.item_name = u.item_name AND i.item_make = u.item_make AND i.item_model = u.item_model ";
            string query = "SELECT i.item_name,i.item_make,i.item_model,i.total_qty,u.EID,u.process,u.edit_qty,u.edit_date,u.loc,u.cause FROM item i JOIN users u ON i.item_name = u.item_name AND i.item_make = u.item_make AND i.item_model = u.item_model ";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ReplaceNullWithNA(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dr[dc] == DBNull.Value)
                    {
                        dr[dc] = "NA";
                    }
                }
            }
            return dt;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if(DateTime.TryParse(txtStartDate.Text, out startDate) && DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                DataTable filteredData = GetFilteredData(startDate, endDate);
                GridView1.DataSource= filteredData;
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
            string query = "SELECT i.item_name,i.item_make,i.item_model,i.total_qty,u.EID,u.process,u.edit_qty,u.edit_date,u.loc,u.cause FROM item i JOIN users u ON i.item_name = u.item_name AND i.item_make = u.item_make AND i.item_model = u.item_model WHERE edit_date BETWEEN @startDate AND @endDate ";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@startDate",startDate);
                cmd.Parameters.AddWithValue("@endDate",endDate);

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