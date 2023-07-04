using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LogInButton.Visible = true;
                    LogOutButton.Visible = false;
                    HelloButton.Visible = false;
                    LinkButton1.Visible = true;//admin login button
                }
                else if (Session["role"].Equals("user"))
                {
                    LogInButton.Visible = false;
                    LogOutButton.Visible = true;
                    HelloButton.Visible = true;
                    HelloButton.Text = "Hello "+ Session["username"].ToString();
                    LinkButton1.Visible = true;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LogInButton.Visible = false;
                    LogOutButton.Visible = true;
                    HelloButton.Visible = false;
                    //HelloButton.Text = "Hello Admin";
                    LinkButton1.Visible = false;
                }

            }catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogIn.aspx");
        }
        protected void HelloButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("signIn.aspx");
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LogInButton.Visible = true;
            LogOutButton.Visible = false;
            HelloButton.Visible = false;
            LinkButton1.Visible = true;//admin login button

            Response.Redirect("index.aspx");
        }

        
    }
}