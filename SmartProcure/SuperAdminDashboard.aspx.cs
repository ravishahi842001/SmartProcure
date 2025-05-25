using System;
using System.Data; // For DataTable
using MySql.Data.MySqlClient;
using System.Web.UI; // For Page

namespace SmartProcure
{
    public partial class SuperAdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // --- Security Check (CRITICAL) ---
            // Ensure only SuperAdmins can access this page
            if (Session["Role"] == null || Session["Role"].ToString() != "SuperAdmin")
            {
                Response.Redirect("Login.aspx"); // Redirect to login if not authenticated or not a SuperAdmin
                return; // Stop further execution
            }

            if (!IsPostBack) // Only load data on the initial page load, not on postbacks
            {
                // Display Welcome Message
                if (Session["UserEmail"] != null)
                {
                    lblWelcome.Text = $"Welcome, {Session["UserEmail"].ToString()}!";
                }
                else
                {
                    lblWelcome.Text = "Welcome, Super Admin!";
                }

                // Load Dashboard Data
                LoadItemRequests();
                LoadPriceSubmissions();
                LoadRecentUsers();
            }
        }

        private void LoadItemRequests()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                // Query to get recent item requests.
                // Assuming 'Requests' table has RequestId, Category, Quantity, Location, Status, UserId
                // and maybe a RequestDate column (which is highly recommended).
                // If you don't have RequestDate, ORDER BY RequestId DESC might be a substitute.
                string query = "SELECT RequestId, Category, Quantity, Location, Status " +
                               "FROM Requests ORDER BY RequestId DESC LIMIT 10"; // Get latest 10 requests

                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    gvItemRequests.DataSource = dt;
                    gvItemRequests.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging, but show a generic message to the user
                    // In production, replace this with a proper logging mechanism (e.g., NLog, Serilog)
                    System.Diagnostics.Debug.WriteLine($"Error loading item requests: {ex.Message}");
                    lblWelcome.Text = $"Error loading item requests. Please try again later.";
                }
            }
        }

        private void LoadPriceSubmissions()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                // Query to get recent price submissions.
                // It joins Quotations with GroupedRequests and Vendors to get more meaningful information.
                // Assuming your tables: Quotations (QuoteId, GroupId, VendorId, Price),
                // GroupedRequests (GroupId, Category, Location, TotalQuantity),
                // Vendors (VendorId, Name)
                string query = @"
                    SELECT
                        q.QuoteId,
                        gr.Category,
                        gr.Location,
                        gr.TotalQuantity,
                        v.Name AS VendorName,
                        q.Price
                    FROM Quotations q
                    JOIN GroupedRequests gr ON q.GroupId = gr.GroupId
                    JOIN Vendors v ON q.VendorId = v.VendorId
                    ORDER BY q.QuoteId DESC LIMIT 10"; // Get latest 10 submissions

                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    gvPriceSubmissions.DataSource = dt;
                    gvPriceSubmissions.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the exception
                    System.Diagnostics.Debug.WriteLine($"Error loading price submissions: {ex.Message}");
                    lblWelcome.Text = $"Error loading price submissions. Please try again later.";
                }
            }
        }

        private void LoadRecentUsers()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                // Query to get recent user registrations.
                // Assuming 'Users' table has UserId, Name, Email, RegistrationDate (if you added it).
                // If not, ORDER BY UserId DESC will get the latest added users.
                string query = "SELECT UserId, Name, Email, Location FROM Users ORDER BY UserId DESC LIMIT 10"; // Get latest 10 users

                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    gvUsers.DataSource = dt;
                    gvUsers.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the exception
                    System.Diagnostics.Debug.WriteLine($"Error loading recent users: {ex.Message}");
                    lblWelcome.Text = $"Error loading recent users. Please try again later.";
                }
            }
        }
    }
}