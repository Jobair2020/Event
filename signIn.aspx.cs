using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event
{
    public partial class signIn : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals(""))
            {
                Response.Write("<script>alert('username empty');</script>");
            }

            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    string enteredHashedPassword = PasswordHasher.GenerateHash(TextBox2.Text.Trim());

                    SqlCommand cmd = new SqlCommand("select * from user_table where user_id='" + TextBox1.Text.Trim() + "' AND password='" + enteredHashedPassword.ToString() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //dr.GetValue(1) references to full_name;
                            Response.Write("<script>alert('Login successful');</script>");
                            Session["username"] = dr.GetValue(0).ToString();//user_id
                            Session["fullname"] = dr.GetValue(1).ToString();
                            Session["role"] = "user";
                            Session["status"] = dr.GetValue(10).ToString();

                        }
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid user');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        
            

        }
    }
}