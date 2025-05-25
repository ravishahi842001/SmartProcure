<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VendorLogin.aspx.cs" Inherits="VendorLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendor Login</title>
    <style>
        body { font-family: Arial; background-color: #f2f2f2; }
        .container { width: 400px; margin: auto; margin-top: 80px; background: #fff; padding: 30px; box-shadow: 0px 0px 10px #ccc; border-radius: 10px; }
        .form-row { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; }
        input { width: 100%; padding: 8px; }
        .btn { background: #007bff; color: white; padding: 10px; border: none; cursor: pointer; width: 100%; border-radius: 5px; }
        .message { margin-top: 10px; font-weight: bold; color: red; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Vendor Login</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="message" />

            <div class="form-row">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" />
            </div>

            <div class="form-row">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>

            <div class="form-row">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
