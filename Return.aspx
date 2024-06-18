<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Return.aspx.cs" Inherits="ConsumablesPortal.Return" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- 
    
        To Do List: 
            Aim:
                1. Subtract the values from database

            Frontend:
                1. dropdown list main select option lana hai list ki jagah
                2. hardcodeing of ddl
                3. Location ko database se connect karna hai ?? 
                !! database ki jagah location ko "type" ya "hardcode" karna zyada accha nhai hoga !!

            Backend:
                1. PK -> Item Name + Item Make + Item model 
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
                                        Return Form
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
                                        <asp:ListItem>a01</asp:ListItem>
                                        <asp:ListItem>a02</asp:ListItem>
                                        <asp:ListItem>a03</asp:ListItem>
                                        <asp:ListItem>a04</asp:ListItem>
                                        <asp:ListItem>a05</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Item Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="SingleLine" placeholder="Item Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Item Make</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="SingleLine" placeholder="Item Make"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Item Model</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="SingleLine" placeholder="Item Model"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Quantity</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Quantity"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Location</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="True" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block " ID="Button1" runat="server" Text="RETURN" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block " ID="Button3" runat="server" Text="RESET" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
