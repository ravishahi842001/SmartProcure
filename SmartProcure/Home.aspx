<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>User Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .dashboard-card {
            border-radius: 20px;
            padding: 30px;
            background: white;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        .dashboard-heading {
            font-weight: bold;
            color: #2c3e50;
        }

        .table thead {
            background-color: #343a40;
            color: white;
        }

        .btn-primary {
            border-radius: 10px;
            padding: 10px 20px;
            font-weight: bold;
        }

        .grid-title {
            margin-top: 30px;
            font-size: 20px;
            color: #34495e;
        }

        .welcome-msg {
            font-size: 18px;
            color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="dashboard-card">
                <h2 class="dashboard-heading">👋 Welcome to Your Dashboard</h2>
                <p class="welcome-msg">Here you can see your previous product requests and create new ones.</p>

                <asp:Button ID="btnNewRequest" runat="server" Text="➕ Request New Product" CssClass="btn btn-primary mt-3" OnClick="btnNewRequest_Click" />

                <h4 class="grid-title">📦 Your Product Requests</h4>
                <asp:GridView ID="gvRequests" runat="server" CssClass="table table-striped table-bordered mt-3" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lblMsg" runat="server" CssClass="text-danger mt-2 d-block" />
            </div>
        </div>
    </form>
</body>
</html>
