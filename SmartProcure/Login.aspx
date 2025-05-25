<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login - SmartProcure</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(to right, #f0f2f5, #ffffff);
        }

        .login-box {
            margin-top: 100px;
            background-color: #fff;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0px 5px 20px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #0d6efd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-5 login-box">
                    <h2 class="text-center mb-4">User Login</h2>

                    <div class="mb-3">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                    </div>
                    <div class="d-grid mb-3">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                    <div class="text-center">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
