using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Event
{
    public partial class contact : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddContactRecord();

        }

        void AddContactRecord()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(strcon);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                String sql = "INSERT INTO contact_table (name,email,subject,message) values(@name,@email,@subject,@message)";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);



                
                sqlCommand.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@subject", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@message", TextBox4.Text.Trim());

                

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Response.Write("<script>alert('information Sent');</script>");

                ClearForm();    
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            
        }
    }
}