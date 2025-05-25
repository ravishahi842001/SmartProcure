<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperAdminDashboard.aspx.cs" Inherits="SmartProcure.SuperAdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Super Admin Dashboard - SmartProcure</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .dashboard-container {
            margin-top: 50px;
        }
        .dashboard-card {
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
            margin-bottom: 30px; /* Added for spacing between cards */
        }
        .dashboard-header {
            background-color: #0d6efd;
            color: white;
            padding: 20px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }
        .dashboard-body {
            padding: 20px;
        }
        .section-header {
            background-color: #e9ecef;
            padding: 15px;
            border-bottom: 1px solid #dee2e6;
            margin-bottom: 15px;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container dashboard-container">
            <div class="row justify-content-center">
                <div class="col-md-10"> <%-- Increased column width for more content --%>
                    <div class="card dashboard-card">
                        <div class="dashboard-header">
                            <h3 class="mb-0">Super Admin Dashboard</h3>
                        </div>
                        <div class="dashboard-body">
                            <asp:Label ID="lblWelcome" runat="server" CssClass="h5 mb-4 text-primary"></asp:Label>
                            <p>Welcome to the Super Admin Dashboard. Here you can monitor system activities and manage core components.</p>
                        </div>
                    </div>

                    <div class="card dashboard-card">
                        <div class="section-header">
                            <h4>Recent Item Requests</h4>
                        </div>
                        <div class="dashboard-body">
                            <asp:GridView ID="gvItemRequests" runat="server" AutoGenerateColumns="true"
                                CssClass="table table-striped table-bordered" HeaderStyle-CssClass="bg-primary text-white">
                            </asp:GridView>
                            <a href="ManageRequests.aspx" class="btn btn-outline-primary mt-3">View All Requests</a>
                        </div>
                    </div>

                    <div class="card dashboard-card">
                        <div class="section-header">
                            <h4>Recent Vendor Price Submissions</h4>
                        </div>
                        <div class="dashboard-body">
                            <asp:GridView ID="gvPriceSubmissions" runat="server" AutoGenerateColumns="true"
                                CssClass="table table-striped table-bordered" HeaderStyle-CssClass="bg-success text-white">
                            </asp:GridView>
                            <a href="ManageSubmissions.aspx" class="btn btn-outline-success mt-3">View All Submissions</a>
                        </div>
                    </div>

                    <div class="card dashboard-card">
                        <div class="section-header">
                            <h4>Recent User Registrations</h4>
                        </div>
                        <div class="dashboard-body">
                            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="true"
                                CssClass="table table-striped table-bordered" HeaderStyle-CssClass="bg-info text-white">
                            </asp:GridView>
                            <a href="ManageUsers.aspx" class="btn btn-outline-info mt-3">Manage All Users</a>
                        </div>
                    </div>

                    <div class="card dashboard-card">
                         <div class="section-header">
                            <h4>Quick Actions</h4>
                        </div>
                        <div class="dashboard-body">
                            <div class="list-group">
                                <a href="ManageAdmins.aspx" class="list-group-item list-group-item-action">Manage Admins</a>
                                <a href="ManageUsers.aspx" class="list-group-item list-group-item-action">Manage Users</a>
                                <a href="SystemSettings.aspx" class="list-group-item list-group-item-action">System Settings</a>
                                <a href="Reports.aspx" class="list-group-item list-group-item-action">View Reports</a>
                                <a href="Logout.aspx" class="list-group-item list-group-item-action text-danger">Logout</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>