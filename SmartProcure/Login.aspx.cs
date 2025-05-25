using System;
using MySql.Data.MySqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        using (MySqlConnection con = new MySqlConnection(connStr))
        {
            try
            {
                con.Open();

                // Step 1: Authenticate User
                string userQuery = "SELECT UserId FROM Users WHERE Email = @Email AND Password = @Password";
                MySqlCommand userCmd = new MySqlCommand(userQuery, con);
                userCmd.Parameters.AddWithValue("@Email", email);
                userCmd.Parameters.AddWithValue("@Password", password);
                object userIdObj = userCmd.ExecuteScalar();

                if (userIdObj != null)
                {
                    int userId = Convert.ToInt32(userIdObj);
                    Session["UserId"] = userId;
                    Session["UserEmail"] = email;

                    // Step 2: Check for SuperAdmin
                    string superAdminQuery = "SELECT COUNT(*) FROM SuperAdmins WHERE UserId = @UserId AND IsApproved = 1";
                    MySqlCommand superAdminCmd = new MySqlCommand(superAdminQuery, con);
                    superAdminCmd.Parameters.AddWithValue("@UserId", userId);
                    int isSuperAdmin = Convert.ToInt32(superAdminCmd.ExecuteScalar());

                    if (isSuperAdmin > 0)
                    {
                        // ✅ SuperAdmin login confirmed
                        Session["Role"] = "SuperAdmin";
                        Response.Redirect("SuperAdminDashboard.aspx");
                        return;
                    }

                    // Step 3: Check for Approved Admin
                    string adminQuery = "SELECT BranchLocation FROM Admins WHERE UserId = @UserId AND IsApproved = 1";
                    MySqlCommand adminCmd = new MySqlCommand(adminQuery, con);
                    adminCmd.Parameters.AddWithValue("@UserId", userId);
                    object branchLocationObj = adminCmd.ExecuteScalar();

                    if (branchLocationObj != null)
                    {
                        Session["Role"] = "Admin";
                        Session["BranchLocation"] = branchLocationObj.ToString();
                        Response.Redirect("AdminDashboard.aspx");
                        return;
                    }

                    // Step 4: Default to Normal User
                    Session["Role"] = "User";
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid email or password.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }
}
