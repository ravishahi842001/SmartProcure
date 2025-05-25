<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorDashboard.aspx.cs" Inherits="ProcMart.VendorDashboard" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Welcome, <%= Session["VendorName"] %></h2>
            <p>Category: <%= Session["VendorCategory"] %></p>
            <p>Location: <%= Session["VendorLocation"] %></p>

            <asp:Label ID="lblMessage" runat="server" ForeColor="red" Visible="false" CssClass="mb-3"></asp:Label>

            <h4>Grouped Requests</h4>
            <asp:GridView ID="gvGroupedRequests" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" EmptyDataText="No requests found">
                <Columns>
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="TotalQuantity" HeaderText="Total Quantity" />
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSubmitPrice" runat="server" Text="Submit Price"
                                        CommandArgument='<%# Eval("GroupId") %>' OnClick="btnSubmitPrice_Click" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
