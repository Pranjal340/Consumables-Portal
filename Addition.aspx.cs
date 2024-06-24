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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // FOR ADDITION
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                Response.Write("Connection is OK !!!");
                SqlCommand cmd = new SqlCommand("insert into item values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')",con);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("INSERT INTO users (EID, item_name, item_make, item_model, process, edit_qty, edit_date, loc, cause) VALUES (@EID, @item_name, @item_make, @item_model, @process, @edit_qty, @edit_date, @loc, @cause)", con);
                cmd2.Parameters.AddWithValue("@EID", DBNull.Value);         //NULL value
                cmd2.Parameters.AddWithValue("@item_name", TextBox1.Text);
                cmd2.Parameters.AddWithValue("@item_make", TextBox2.Text);
                cmd2.Parameters.AddWithValue("@item_model", TextBox3.Text);
                cmd2.Parameters.AddWithValue("@process", "Add");       // Specific value for process
                cmd2.Parameters.AddWithValue("@edit_qty", TextBox4.Text);
                cmd2.Parameters.AddWithValue("@edit_date", DateTime.Now);   // Current date
                cmd2.Parameters.AddWithValue("@loc", DBNull.Value);         // NULL value
                cmd2.Parameters.AddWithValue("@cause", DBNull.Value);       // NULL value
            
                cmd2.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Item Added');window.location='home.aspx'; ", true);

            }
            
            catch(Exception Ex) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Cannot add the same product repeatedly. Please update it');window.location='home.aspx'; ", true);
                //Console.WriteLine("An error occurred: " + Ex.Message);
                //Console.WriteLine("Cannot add the same product repeatedly. Please update it"); //Not Working or showing message
            }

        }

        // FOR RESET
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = "";
        }
    }
}