using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace ProcMart
{
    public partial class VendorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGroupedRequests();
            }
        }

        private void LoadGroupedRequests()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"
                    SELECT GroupId, Category, Location, TotalQuantity
                    FROM GroupedRequests
                    WHERE Category = @VendorCategory AND Location = @VendorLocation
                    ORDER BY Category, Location;
                ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@VendorCategory", Session["VendorCategory"]);
                da.SelectCommand.Parameters.AddWithValue("@VendorLocation", Session["VendorLocation"]);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvGroupedRequests.DataSource = dt;
                    gvGroupedRequests.DataBind();
                    gvGroupedRequests.Visible = true;
                    lblMessage.Visible = false;
                }
                else
                {
                    gvGroupedRequests.Visible = false;
                    lblMessage.Text = "No requests found.";
                    lblMessage.Visible = true;
                }
            }
        }

        protected void btnSubmitPrice_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int groupId = Convert.ToInt32(btn.CommandArgument);
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtPrice = (TextBox)row.FindControl("txtPrice");

            if (txtPrice != null && decimal.TryParse(txtPrice.Text, out decimal price))
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = @"
                        INSERT INTO Quotations (GroupId, VendorId, Price)
                        VALUES (@GroupId, @VendorId, @Price)
                        ON DUPLICATE KEY UPDATE Price = @Price;
                    ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);
                    cmd.Parameters.AddWithValue("@VendorId", Session["VendorID"]);
                    cmd.Parameters.AddWithValue("@Price", price);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadGroupedRequests();
            }
            else
            {
                lblMessage.Text = "Please enter a valid price.";
                lblMessage.Visible = true;
            }
        }
    }
}
