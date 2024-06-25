<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DateQty.aspx.cs" Inherits="ConsumablesPortal.DateQty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
    <style>
        body {
            background-image: url('imgs/HaziraNew.jpg'); /* Replace with your image path */
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            background-attachment: fixed;
        }

        .table {
            background-color: rgba(255, 255, 255, 0.8); /* Slightly transparent white background */
            padding: 20px; /* Add some padding for better visual */
            border-radius: 10px; /* Optional: rounded corners */
            box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.2); /* Optional: add some shadow for better visibility */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mx-1 my-5 justify-content-center text-center">
        <div class="col-12">
            <i>
                <h1>
                    Datewise Quantity Report
                </h1>
            </i>
        </div>
    </div>

    <div class="container-fluid text-center py-2" style="margin:auto;">
        <asp:Label ID="Label11" runat="server" Text="Start Date"></asp:Label>
        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Text="End Date"></asp:Label>
        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
    </div>

    <div style="display: flex; justify-content: center; align-items: center; height: auto">
    
        <asp:GridView class="table table-responsive table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Sr No." SortExpression="Sr No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Name" SortExpression="Item Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Make" SortExpression="Item Make">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("item_make") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Model" SortExpression="Item Model">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("item_model") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("today_date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("today_qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
