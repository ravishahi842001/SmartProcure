using System;
using System.Data;
using MySql.Data.MySqlClient;

public partial class GroupRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GroupRequestsAndShow();
        }
    }

    private void GroupRequestsAndShow()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

        using (MySqlConnection con = new MySqlConnection(connStr))
        {
            con.Open();

            // 1. Clear old groupings
            string clearQuery = "DELETE FROM GroupedRequests";
            MySqlCommand clearCmd = new MySqlCommand(clearQuery, con);
            clearCmd.ExecuteNonQuery();

            // 2. Insert new grouped data
            string groupQuery = @"
                INSERT INTO GroupedRequests (Category, Location, TotalQuantity)
                SELECT Category, Location, SUM(Quantity)
                FROM Requests
                GROUP BY Category, Location;
            ";

            MySqlCommand groupCmd = new MySqlCommand(groupQuery, con);
            groupCmd.ExecuteNonQuery();

            // 3. Show updated groups in grid
            string fetchQuery = "SELECT * FROM GroupedRequests";
            MySqlDataAdapter da = new MySqlDataAdapter(fetchQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvGroupedRequests.DataSource = dt;
            gvGroupedRequests.DataBind();
        }
    }
}
