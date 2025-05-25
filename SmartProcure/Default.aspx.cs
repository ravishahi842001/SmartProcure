using System;
using System.Web.UI;

namespace YourProjectNamespace
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No action on page load for now
        }

        protected void btnUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnUserRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnVendorLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorLogin.aspx");
        }

        protected void btnVendorRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorRegister.aspx");
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void btnAdminRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegister.aspx");
        }
    }
}
