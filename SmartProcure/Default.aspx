<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourProjectNamespace.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>SmartProcure | Landing Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body, html {
            height: 100%;
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
        }

        .bg-cover {
            background: url('Images/bg.jpg') no-repeat center top fixed;
            background-size: cover;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }

        .navbar-custom {
            background-color: rgba(0, 0, 0, 0.85);
        }

        .navbar-custom .navbar-brand,
        .navbar-custom .nav-link {
            color: #fff !important;
            font-weight: 600;
        }

        .navbar-custom .nav-link:hover {
            color: #ffc107 !important;
        }

        .footer-info {
            margin-top: auto;
            background: rgba(255, 255, 255, 0.9);
            padding: 30px 20px;
            text-align: center;
            color: #333;
        }

        .footer-info h4 {
            font-weight: bold;
            color: #000;
        }

        .footer-info p {
            font-size: 16px;
        }

        .nav-link {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-cover">
            <!-- Navbar -->
            <nav class="navbar navbar-expand-lg navbar-custom">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">SmartProcure</a>
                    <button class="navbar-toggler text-white" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <asp:LinkButton ID="btnUserLogin" runat="server" CssClass="nav-link" OnClick="btnUserLogin_Click">User Login</asp:LinkButton>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="btnUserRegister" runat="server" CssClass="nav-link" OnClick="btnUserRegister_Click">User Register</asp:LinkButton>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="btnVendorLogin" runat="server" CssClass="nav-link" OnClick="btnVendorLogin_Click">Vendor Login</asp:LinkButton>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="btnVendorRegister" runat="server" CssClass="nav-link" OnClick="btnVendorRegister_Click">Vendor Register</asp:LinkButton>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="btnAdminLogin" runat="server" CssClass="nav-link" OnClick="btnAdminLogin_Click">Admin Login</asp:LinkButton>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="btnAdminRegister" runat="server" CssClass="nav-link" OnClick="btnAdminRegister_Click">Admin Register</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <!-- About Us Section -->
            <!-- About Us Section -->
<section class="py-5" style="background-color: rgba(255, 255, 255, 0.9); color: #000; position: absolute; bottom: 80px; left: 50px; max-width: 500px; border-radius: 12px; padding: 20px;">
    <div>
        <h2>About SmartProcure</h2>
        <p class="lead">
            SmartProcure is a unified platform that connects users with verified vendors. We streamline the procurement process by grouping user requests, inviting vendor quotations, and ensuring the best deal reaches the consumer. Our mission is to make everyday purchasing smarter, faster, and more affordable—whether you're buying individually or in bulk.
        </p>
    </div>
</section>


            <!-- Footer -->
            <footer class="text-center text-white p-3" style="background: rgba(0, 0, 0, 0.5); backdrop-filter: blur(4px); border-top: 1px solid rgba(255,255,255,0.1);">
                <p class="mb-0">© 2025 SmartProcure. All rights reserved.<br />Built by Ravi Kumar & Shalu Kumari during Internship.</p>
            </footer>
        </div>
    </form>

    <!-- Bootstrap Script -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
