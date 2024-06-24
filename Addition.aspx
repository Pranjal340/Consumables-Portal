<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Addition.aspx.cs" Inherits="ConsumablesPortal.Addition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
    body {
        background-image: url('imgs/HaziraNew.jpg'); /* Replace with your image path */
        background-size: cover;
        background-position: center;
        background-repeat: no-repeat;
        background-attachment: fixed;
    }

    .container {
        background-color: rgba(255, 255, 255, 0.8); /* Slightly transparent white background */
        padding: 20px; /* Add some padding for better visual */
        border-radius: 10px; /* Optional: rounded corners */
        box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.2); /* Optional: add some shadow for better visibility */
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- 
    
        To Do List:
            Aim:
                DONE!! - 1. Addition of data in database
                DONE!! - 2. Update the data in database

            Frontend:
                1. dropdown list main select option lana hai list ki jagah
                2. hardcodeing of ddl
                DONE!! - 3. Validation Controls

            Backend:    
                DONE!! - 1.PK -> Item Name + Item Make + Item model 
                2. Make and Model if not selected then take a value by default as it is a primary key
                DONE!! - 3. seperate functionality of add and update button. addition cannot be performed on an item already in the database and vice versa
                DONE!! - 4. Addition main same item name , make aur model daalne par exception lag jana chahiye 

    --%>


    <div class="container">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>
                                        Addition Form
                                    </h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Item Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="SingleLine" placeholder="Item Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox1" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Item Make</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="SingleLine" placeholder="Item Make"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox2" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Item Model</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="SingleLine" placeholder="Item Model"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox3" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Quantity</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Quantity"></asp:TextBox>
                                    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox4" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" ValidationGroup="Group1" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block " ID="Button3" runat="server" Text="RESET" OnClick="Button3_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
