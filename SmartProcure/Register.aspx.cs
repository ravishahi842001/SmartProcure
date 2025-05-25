using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

public partial class Register : System.Web.UI.Page
{
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        using (MySqlConnection con = new MySqlConnection(connStr))
        {
            string query = "INSERT INTO Users (Name, Email, Password, Location) VALUES (@Name, @Email, @Password, @Location)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Location", txtLocation.Text);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    lblMsg.Text = "User registered successfully!";
                    ClearForm();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMsg.Text = "Something went wrong.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }

    private void ClearForm()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtLocation.Text = "";
    }
}
