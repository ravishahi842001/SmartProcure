<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VendorRegister.aspx.cs" Inherits="VendorRegister" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Registration</title>
    <style>
        body { font-family: Arial; background-color: #f2f2f2; }
        .container { width: 400px; margin: auto; margin-top: 50px; background: #fff; padding: 30px; box-shadow: 0px 0px 10px #ccc; border-radius: 10px; }
        .form-row { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; }
        input, select { width: 100%; padding: 8px; }
        .btn { background: #28a745; color: white; padding: 10px; border: none; cursor: pointer; width: 100%; border-radius: 5px; }
        .message { margin-top: 10px; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Vendor Registration</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="message" />

            <div class="form-row">
                <label>Name:</label>
                <asp:TextBox ID="txtName" runat="server" />
            </div>

            <div class="form-row">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" />
            </div>

            <div class="form-row">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>

            <div class="form-row">
                <label>Category:</label>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Text="Select Category" Value="" />
                    <asp:ListItem Text="Electrical" />
                    <asp:ListItem Text="Stationery" />
                    <asp:ListItem Text="Cleaning" />
                </asp:DropDownList>
            </div>

            <div class="form-row">
                <label>Supply Location:</label>
                <asp:TextBox ID="txtLocation" runat="server" />
            </div>

            <div class="form-row">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
