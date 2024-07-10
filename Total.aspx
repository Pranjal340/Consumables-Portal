<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Total.aspx.cs" Inherits="ConsumablesPortal.Total" %>
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
            background-color: rgba(255, 255, 255, 1); /* Slightly transparent white background */
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
                    Final Quantity Report
                </h1>
            </i>
        </div>
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
                <asp:TemplateField HeaderText="Total Quantity" SortExpression="Total Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("total_qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
