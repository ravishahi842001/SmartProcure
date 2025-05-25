using System;
using System.Data;
using MySql.Data.MySqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            LoadUserRequests();
        }
    }

    private void LoadUserRequests()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        using (MySqlConnection con = new MySqlConnection(connStr))
        {
            try
            {
                con.Open();

                // Get UserId from session email
                string getUserIdQuery = "SELECT UserId FROM Users WHERE Email = @Email";
                MySqlCommand cmdUser = new MySqlCommand(getUserIdQuery, con);
                cmdUser.Parameters.AddWithValue("@Email", Session["UserEmail"].ToString());
                object result = cmdUser.ExecuteScalar();

                if (result != null)
                {
                    int userId = Convert.ToInt32(result);

                    string query = "SELECT Category, Quantity, Location, Status FROM Requests WHERE UserId = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvRequests.DataSource = dt;
                    gvRequests.DataBind();
                }
                else
                {
                    lblMsg.Text = "User not found.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }

    protected void btnNewRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("RequestProduct.aspx");
    }
}
