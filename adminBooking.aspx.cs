using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Event
{
    public partial class adminBooking : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_hall, global_current_hall, global_issued_hall;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkIfHallExists())
            {
                Response.Write("<script>alert('Hall Already Exists, try some other Hall ID');</script>");
            }
            else
            {
                addNewHall();
            }

        }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateHallByID();
        }
        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deletehallByID();
        }
        //gp btn
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetHallById();
        }


        void deletehallByID()
        {
            if (checkIfHallExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from hall_table WHERE hall_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Hall Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Hall ID');</script>");
            }
        }
        void updateHallByID()
        {

            if (checkIfHallExists())
            {
                try
                {

                    int actual_hall = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_hall = Convert.ToInt32(TextBox5.Text.Trim());

                    if (global_actual_hall == actual_hall)
                    {

                    }
                    else
                    {
                        if (actual_hall < global_issued_hall)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_hall = actual_hall - global_issued_hall;
                            TextBox5.Text = "" + current_hall;
                        }
                    }

                    string category = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        category = category + ListBox1.Items[i] + ",";
                    }
                    category = category.Remove(category.Length - 1);

                    string filepath = "~/Halls_images/g6.jpg";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("Halls_images/" + filename));
                        filepath = "~/Halls_images/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE hall_table set hall_name=@hall_name,city=@city,type=@type, category=@category,  venue=@venue,booking_date=@booking_date,  status=@status, price=@price, seat=@seat,actual_hall=@actual_hall,current_hall=@current_hall, event_description=@event_description,hall_img_link=@hall_img_link WHERE hall_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Hall_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", DropDownList1.SelectedItem.Value);
                    
                    cmd.Parameters.AddWithValue("@type", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@venue", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@booking_date", TextBox3.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("@status", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@seat", TextBox11.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("@actual_hall", actual_hall.ToString());
                    cmd.Parameters.AddWithValue("@current_hall", current_hall.ToString());
                    cmd.Parameters.AddWithValue("@event_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@hall_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Hall Updated Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Hall ID');</script>");
            }
        }


        void GetHallById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from hall_table WHERE hall_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["hall_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["booking_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["status"].ToString();
                    TextBox10.Text = dt.Rows[0]["price"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["seat"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_hall"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_hall"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["event_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_hall"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_hall"].ToString()));

                    DropDownList1.SelectedValue = dt.Rows[0]["city"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["venue"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["type"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] category = dt.Rows[0]["category"].ToString().Trim().Split(',');
                    for (int i = 0; i < category.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == category[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_hall = Convert.ToInt32(dt.Rows[0]["actual_hall"].ToString().Trim());
                    global_current_hall = Convert.ToInt32(dt.Rows[0]["current_hall"].ToString().Trim());
                    global_issued_hall = global_actual_hall - global_current_hall;
                    global_filepath = dt.Rows[0]["hall_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Hall ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfHallExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from hall_table where hall_id='" + TextBox1.Text.Trim() + "' OR hall_name='" + TextBox2.Text.Trim() + "';", con);
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

        void addNewHall()
        {
            try
            {
                string category = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    category = category + ListBox1.Items[i] + ",";
                }
                // category = Adventure,Self Help,
                category = category.Remove(category.Length - 1);

                string filepath = "~/Halls_images/g6.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("Halls_images/" + filename));
                filepath = "~/Halls_images/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO hall_table(hall_id,hall_name,city,type,category,venue,booking_date,status,price,seat,actual_hall,current_hall,event_description,hall_img_link) values(@hall_id,@hall_name,@city,@type,@category,@venue,@booking_date,@status,@price,@seat,@actual_hall,@current_hall,@event_description,@hall_img_link)", con);

                cmd.Parameters.AddWithValue("@hall_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@hall_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@city", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@type", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@venue", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@booking_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@status", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@price", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@seat", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_hall", TextBox4.Text.Trim());

                cmd.Parameters.AddWithValue("@current_hall", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@event_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@hall_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Hall added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




        /*void fillDropDownValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_table;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }*/
    }
}