using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]==null)
                {
                    LinkButton5.Visible = true;//signin
                    LinkButton2.Visible = true;//signup

                    LinkButton3.Visible = false;//logout
                    LinkButton7.Visible = false;//hello amin
                    LinkButton6.Visible = true;//admin sing in

                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;


                }
                else if (Session["role"].Equals("admin"))
                {
                    

                    LinkButton5.Visible = false;//signin
                    LinkButton2.Visible = false;//signup
                    LinkButton3.Visible = true;//logout
                    LinkButton7.Visible = true;//hello amin
                    LinkButton7.Text = "Hellow admin";
                    LinkButton6.Visible = false;//admin sing in

                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogIn.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBooking.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminEventIssuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminUserManagement.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("signIn.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signUp.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("events.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton5.Visible = true;//signin
            LinkButton2.Visible = true;//signup

            LinkButton3.Visible = false;//logout
            LinkButton7.Visible = false;//hello amin
            LinkButton6.Visible = true;//admin sing in

            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;

            Response.Redirect("index.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}