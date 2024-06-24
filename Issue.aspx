<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issue.aspx.cs" Inherits="ConsumablesPortal.Issue" %>
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
                DONE!! - 1. Subtract the values from database

            Frontend:
                1. dropdown list main select option lana hai list ki jagah
                2. hardcodeing of ddl
                3. Location ko database se connect karna hai ?? 
                !! database ki jagah location ko "type" ya "hardcode" karna zyada accha nhai hoga !!
                DONE!! - 4. Validation Controls

            Backend:
                DONE!! - 1. PK -> Item Name + Item Make + Item model 
                2. Make and Model if not selected then take a value by default as it is a primary key
                3. Location mandatory karna chahiye ya nahi
                4. Cause to optional hoga hi

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
                                        Issue Form
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
                                <label>Employee ID</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="true">
                                        <asp:ListItem Text="Select an option..." Value="" />
                                        <asp:ListItem Text="a01" Value="a01"></asp:ListItem>
                                        <asp:ListItem Text="a02" Value="a02"></asp:ListItem>
                                        <asp:ListItem Text="a03" Value="a03"></asp:ListItem>
                                        <asp:ListItem Text="a04" Value="a04"></asp:ListItem>
                                        <asp:ListItem Text="a05" Value="a05"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList1" InitialValue="" ErrorMessage="Please select an option." ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Item Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Mandatory" ControlToValidate="DropDownList2" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Item Make</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Mandatory" ControlToValidate="DropDownList3" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Item Model</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Mandatory" ControlToValidate="DropDownList4" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Quantity</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Quantity"></asp:TextBox>
                                    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox4" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Location</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="SingleLine" placeholder="Location"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Mandatory" ControlToValidate="TextBox5" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Cause</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="MultiLine" placeholder="Reason..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="ISSUE" OnClick="Button1_Click" ValidationGroup="Group1" />
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
