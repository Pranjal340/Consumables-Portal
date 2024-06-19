using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumablesPortal
{
    public partial class Return : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {

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
                cmd.Parameters.AddWithValue("@process", "Return");       // Specific value for process
                cmd.Parameters.AddWithValue("@edit_qty", TextBox4.Text);
                cmd.Parameters.AddWithValue("@edit_date", DateTime.Now);   // Current date
                cmd.Parameters.AddWithValue("@loc", TextBox5.Text);
                cmd.Parameters.AddWithValue("@cause", DBNull.Value);       // NULL value

                cmd.ExecuteNonQuery();


                con.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Item Returned');window.location='home.aspx'; ", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('ERROR!! Form NOT Sumbitted');window.location='home.aspx'; ", true);
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = "";
        }
    }
}