using System;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class VendorRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Nothing for now
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();
        string category = ddlCategory.SelectedValue;
        string location = txtLocation.Text.Trim();

        if (category == "")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Please select a category.";
            return;
        }

        string connStr = ConfigurationManager.ConnectionStrings["SmartProcureDB"]?.ConnectionString;


        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Vendors (Name, Email, Password, Category, SupplyLocation) " +
                               "VALUES (@Name, @Email, @Password, @Category, @Location)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Location", location);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Vendor registered successfully!";
                    txtName.Text = txtEmail.Text = txtPassword.Text = txtLocation.Text = "";
                    ddlCategory.SelectedIndex = 0;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Registration failed.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
