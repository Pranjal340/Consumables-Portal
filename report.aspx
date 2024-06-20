<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="ConsumablesPortal.report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mx-1 my-5 justify-content-center text-center">
        <div class="col-12">
            <i>
                <h1>
                    Report
                </h1>
            </i>
        </div>
    </div>
    <div style="width:90%; margin:auto;">
        <asp:GridView class="table table-responsive table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Item Name" SortExpression="Item Name">
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
                <asp:TemplateField HeaderText="Employee ID" SortExpression="Employee ID">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("EID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process" SortExpression="Process">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("process") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Quantity" SortExpression="Total Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("total_qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit Quantity" SortExpression="Edit Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("edit_qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit Date" SortExpression="Edit Date">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("edit_date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location" SortExpression="Location">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("loc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cause" SortExpression="Cause">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("cause") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
