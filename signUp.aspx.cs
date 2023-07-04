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
    public partial class signUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckUserExists())
            {
                Response.Write("<script>alert('Member Already Exist with this username, try other username');</script>");

            }
            else
            {
                SignUpNewUser();
            }



        }

        //checking the member exists
        bool CheckUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_table where user_id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        //user signup method

        void SignUpNewUser()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(strcon);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                string password = TextBox9.Text.Trim();
                string enteredHashedPassword = PasswordHasher.GenerateHash(password);
                String sql = "INSERT INTO user_table(user_id,full_name,dob,contact_no,email,division,city,pincode,full_address,password,account_status) values(@user_id,@full_name,@dob,@contact_no,@email,@division,@city,@pincode,@full_address,@password,@account_status)";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@user_id", TextBox8.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@division", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", enteredHashedPassword.ToString());
                sqlCommand.Parameters.AddWithValue("@account_status", "pending");
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}