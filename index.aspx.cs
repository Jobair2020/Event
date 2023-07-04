using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event
{
    public partial class index : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        

        //book now
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('You have to Login first');</script>");
                
            }
            else
            {
                AddBookingRecord();

            }
            
        }

        void AddBookingRecord()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(strcon);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                String sql = "INSERT INTO user_booking_table (location,date,time,user_name,phone_no,email,user_id) values(@location,@date,@time,@user_name,@phone_no,@email,@user_id)";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);



                sqlCommand.Parameters.AddWithValue("@location", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@date", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@time", TextBox4.Text.Trim());
               

                sqlCommand.Parameters.AddWithValue("@user_name", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@phone_no", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@user_id", Session["username"]);

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Response.Write("<script>alert('Booking Added');</script>");
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
            TextBox5.Text = "";
            

        }


    }
}