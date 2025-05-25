using System;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class VendorLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // No initialization needed here for now
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                // Select VendorID, Name, Category, and SupplyLocation
                string query = "SELECT VendorID, Name, Category, SupplyLocation FROM Vendors WHERE Email=@Email AND Password=@Password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Save vendor info and category/location for dashboard
                        Session["VendorID"] = reader["VendorID"].ToString();
                        Session["VendorName"] = reader["Name"].ToString();
                        Session["VendorCategory"] = reader["Category"].ToString();
                        Session["VendorLocation"] = reader["SupplyLocation"].ToString();

                        Response.Redirect("VendorDashboard.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid email or password.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
