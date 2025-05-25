<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestProduct.aspx.cs" Inherits="RequestProduct" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Request Product</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h3 class="mb-4">Request a Product</h3>

            <div class="mb-3">
                <label>Category</label>
                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Quantity</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Location</label>
                <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblMsg" runat="server" CssClass="text-success d-block mt-3" />
        </div>
    </form>
</body>
</html>
