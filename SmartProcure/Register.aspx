<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartProcure - User Registration</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(to right, #e3f2fd, #ffffff);
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .register-box {
            margin-top: 80px;
            background-color: #ffffff;
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
                <div class="col-md-5 register-box">
                    <h2 class="text-center mb-4">User Registration</h2>

                    <div class="mb-3">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full Name" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address" TextMode="Email" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" placeholder="Your Location" />
                    </div>
                    <div class="d-grid mb-3">
                        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                    <div class="text-center">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
