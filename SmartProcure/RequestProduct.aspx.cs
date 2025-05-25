using System;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class RequestProduct : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Step 0: Check session
        if (Session["UserId"] == null)
        {
            lblMsg.Text = "⚠️ Session expired. Please login again.";
            return;
        }

        try
        {
            string category = txtCategory.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string location = txtLocation.Text;
            int userId = Convert.ToInt32(Session["UserId"]);

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // Step 1: Insert into Requests Table
                string insertQuery = "INSERT INTO Requests (UserId, Category, Quantity, Location, Status) VALUES (@UserId, @Category, @Quantity, @Location, 'Pending')";
                MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.ExecuteNonQuery();

                // Step 2: Check for existing group
                string checkGroup = "SELECT GroupId FROM GroupedRequests WHERE Category = @Category AND Location = @Location";
                MySqlCommand checkCmd = new MySqlCommand(checkGroup, con);
                checkCmd.Parameters.AddWithValue("@Category", category);
                checkCmd.Parameters.AddWithValue("@Location", location);
                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    // Group exists, update total quantity
                    int groupId = Convert.ToInt32(result);
                    string updateGroup = "UPDATE GroupedRequests SET TotalQuantity = TotalQuantity + @Quantity WHERE GroupId = @GroupId";
                    MySqlCommand updateCmd = new MySqlCommand(updateGroup, con);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                    updateCmd.Parameters.AddWithValue("@GroupId", groupId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // No group exists, insert new group
                    string insertGroup = "INSERT INTO GroupedRequests (Category, Location, TotalQuantity) VALUES (@Category, @Location, @TotalQuantity)";
                    MySqlCommand insertCmd = new MySqlCommand(insertGroup, con);
                    insertCmd.Parameters.AddWithValue("@Category", category);
                    insertCmd.Parameters.AddWithValue("@Location", location);
                    insertCmd.Parameters.AddWithValue("@TotalQuantity", quantity);
                    insertCmd.ExecuteNonQuery();
                }

                lblMsg.Text = "✅ Product request submitted successfully!";
                ClearForm();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "❌ Error: " + ex.Message;
        }
    }

    private void ClearForm()
    {
        txtCategory.Text = "";
        txtQuantity.Text = "";
        txtLocation.Text = "";
    }
}
