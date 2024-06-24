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
    public partial class Issue : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateItemNames();
            }

        }

        // Item Name DDL
        private void PopulateItemNames()
        {
            string query = "SELECT DISTINCT item_name FROM item";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList2.DataSource = reader;
                DropDownList2.DataTextField = "item_name";
                DropDownList2.DataValueField = "item_name";
                DropDownList2.DataBind();
            }

            DropDownList2.Items.Insert(0, new ListItem("--Select Item Name--", "")); // maybe "0"

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "") // maybe be "0"
            {
                PopulateItemMakes(DropDownList1.SelectedValue);
            }
            else
            {
                DropDownList3.Items.Clear();
                DropDownList4.Items.Clear();
            }
        }

        // Item Make DDL
        private void PopulateItemMakes(string itemName)
        {
            string query = "SELECT DISTINCT item_make FROM item WHERE item_name = @item_name";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@item_name", itemName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList3.DataSource = reader;
                DropDownList3.DataTextField = "item_make";
                DropDownList3.DataValueField = "item_make";
                DropDownList3.DataBind();
            }
            DropDownList3.Items.Insert(0, new ListItem("--Select Item Make", ""));
        }


        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "")
            {
                PopulateItemModels(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
            }
            else
            {
                DropDownList4.Items.Clear();
            }
        }

        // Item Model DDL
        private void PopulateItemModels(string itemName, string itemMake)
        {

            string query = "SELECT DISTINCT item_model FROM item WHERE item_name = @item_name AND item_make = @item_make";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@item_name", itemName);
                cmd.Parameters.AddWithValue("@item_make", itemMake);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList4.DataSource = reader;
                DropDownList4.DataTextField = "item_model";
                DropDownList4.DataValueField = "item_model";
                DropDownList4.DataBind();
            }
            DropDownList4.Items.Insert(0, new ListItem("--Select Item Model--", ""));
        }

        // FOR ISSUE
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                Response.Write("Connection is OK !!!");

                string item_name = DropDownList2.SelectedValue;
                string item_make = DropDownList3.SelectedValue;
                string item_model = DropDownList4.SelectedValue;
                int quantityToRemove;
                if (!int.TryParse(TextBox4.Text, out quantityToRemove))
                {
                    ErrorMessage.Text = "Invalid quantity value.";
                    ErrorMessage.Visible = true;

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Invalid quantity value.');window.location='home.aspx'; ", true);

                    return;
                }

                string selectQuery = "SELECT total_qty FROM item WHERE item_name = @item_name AND item_make = @item_make AND item_model = @item_model";
                string updateQuery = "UPDATE item SET total_qty = @total_qty WHERE item_name = @item_name AND item_make = @item_make AND item_model = @item_model";

                int currentQuantity = 0;
                bool itemExists = false;
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@item_name", item_name);
                    selectCommand.Parameters.AddWithValue("@item_make", item_make);
                    selectCommand.Parameters.AddWithValue("@item_model", item_model);



                    object result = selectCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        currentQuantity = Convert.ToInt32(result);
                        itemExists = Convert.ToInt32(result) > 0;
                    }
                    else 
                    {

                        //First this exception will be checked then next one

                        ErrorMessage.Text = "No item with the specified name, make, and model exists.";
                        ErrorMessage.Visible = true;

                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('No item with the specified name, make, and model exists.');window.location='home.aspx'; ", true);

                        return;
                    }
                }
                
                if(!itemExists) 
                {
                    //Second expception to be checked if by chance first misses even though they both are essentially same

                    ErrorMessage.Text = "No item with the specified name, make, and model exists.";
                    ErrorMessage.Visible = true;

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('No item with the specified name, make, and model exists.');window.location='home.aspx'; ", true);

                    return;
                }
                

                if (currentQuantity < quantityToRemove) 
                {
                    ErrorMessage.Text = "Issue Quantity is More than Available Quantity";
                    ErrorMessage.Visible = true;

                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Issue Quantity is More than Available Quantity');window.location='home.aspx'; ", true);

                    return;

                }

                // Calculate the new quantity
                int newQuantity = currentQuantity - quantityToRemove;

                // Issue the quantity
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
                cmd.Parameters.AddWithValue("@item_name", DropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@item_make", DropDownList3.SelectedValue);
                cmd.Parameters.AddWithValue("@item_model", DropDownList4.SelectedValue);
                cmd.Parameters.AddWithValue("@process", "Issue");       // Specific value for process
                cmd.Parameters.AddWithValue("@edit_qty", TextBox4.Text);
                cmd.Parameters.AddWithValue("@edit_date", DateTime.Now);   // Current date
                cmd.Parameters.AddWithValue("@loc", TextBox5.Text);
                cmd.Parameters.AddWithValue("@cause", TextBox6.Text);

                cmd.ExecuteNonQuery();


                con.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('Item Issued');window.location='home.aspx'; ", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('ERROR!! Form NOT Sumbitted');window.location='home.aspx'; ", true);
            }

        }

        // FOR RESET
        protected void Button3_Click(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList2.SelectedValue = DropDownList3.SelectedValue = DropDownList4.SelectedValue = TextBox4.Text = TextBox5.Text = TextBox6.Text = "";
        }
    }
}