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
                cmd2.Parameters.AddWithValue("@EID", DropDownList1.SelectedValue); 
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



        // FOR UPDATE
        protected void Button2_Click(object sender, EventArgs e)
        {

            try { 

                con.Open();
                Response.Write("Connection is OK !!!");

 

                string item_name = TextBox1.Text;
                string item_make = TextBox2.Text;
                string item_model = TextBox3.Text;
                int quantityToAdd;
                if (!int.TryParse(TextBox4.Text, out quantityToAdd))
                {
                    ErrorMessage.Text = "Invalid quantity value.";
                    ErrorMessage.Visible = true;

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Invalid quantity value.');window.location='home.aspx'; ", true);

                    return;
                }
                

                string selectQuery = "SELECT total_qty FROM item WHERE item_name = @item_name AND item_make = @item_make AND item_model = @item_model";
                string updateQuery = "UPDATE item SET total_qty = @total_qty WHERE item_name = @item_name AND item_make = @item_make AND item_model = @item_model";

                int currentQuantity = 0;
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@item_name", item_name);
                    selectCommand.Parameters.AddWithValue("@item_make", item_make);
                    selectCommand.Parameters.AddWithValue("@item_model", item_model);

                    object result = selectCommand.ExecuteScalar();
                    if (result != null)
                    {
                       currentQuantity = Convert.ToInt32(result);
                    }
                    else 
                    {
                        ErrorMessage.Text = "No item with the specified name, make, and model exists.";
                        ErrorMessage.Visible = true;

                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('No item with the specified name, make, and model exists.');window.location='home.aspx'; ", true);

                        return;
                    }

                }

                // Calculate the new quantity
                int newQuantity = currentQuantity + quantityToAdd;

                // Update the quantity
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                {
                   updateCommand.Parameters.AddWithValue("@total_qty", newQuantity);
                   updateCommand.Parameters.AddWithValue("@item_name", item_name);
                   updateCommand.Parameters.AddWithValue("@item_make", item_make);
                   updateCommand.Parameters.AddWithValue("@item_model", item_model);
                   updateCommand.ExecuteNonQuery();
                }



                SqlCommand cmd = new SqlCommand("INSERT INTO users (EID, item_name, item_make, item_model, process, edit_qty, edit_date, loc, cause) VALUES (@EID, @item_name, @item_make, @item_model, @process, @edit_qty, @edit_date, @loc, @cause)", con);
                cmd.Parameters.AddWithValue("@EID", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@item_name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@item_make", TextBox2.Text);
                cmd.Parameters.AddWithValue("@item_model", TextBox3.Text);
                cmd.Parameters.AddWithValue("@process", "Update");       // Specific value for process
                cmd.Parameters.AddWithValue("@edit_qty", TextBox4.Text);
                cmd.Parameters.AddWithValue("@edit_date", DateTime.Now);   // Current date
                cmd.Parameters.AddWithValue("@loc", DBNull.Value);         // NULL value
                cmd.Parameters.AddWithValue("@cause", DBNull.Value);       // NULL value

                cmd.ExecuteNonQuery();



                con.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Item Updated');window.location='home.aspx'; ", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('ERROR!! Form NOT Sumbitted');window.location='home.aspx'; ", true);
            }

        }


        // FOR RESET
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = "";
        }
    }
}