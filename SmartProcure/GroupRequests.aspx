<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupRequests.aspx.cs" Inherits="GroupRequests" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Grouped Requests</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">📊 Grouped Product Requests</h2>
            <asp:GridView ID="gvGroupedRequests" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="True" />
        </div>
    </form>
</body>
</html>
