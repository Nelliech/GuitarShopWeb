using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GuitarShopWebV2
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            string query = "Select ProductCode, Producer, Model, Price From Guitar";
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
             
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var productCode = GridView1.Rows[index].Cells[0].Text;

            string connectionString = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            var userLogin = User.Identity.Name;
            string query = "Select Id Price From ApplicationUser Where Login=@login";
            
            int userId;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@login", userLogin);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }


        }

        public void AddToCart(string productCode, int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            string query = "Select * From Cart Where UserId=@userId";
            bool isRow;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    con.Open();
                    isRow=cmd.ExecuteReader().HasRows;
                    con.Close();
                }
            }

            if (isRow)
            {
                query = "";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        con.Open();
                        isRow = cmd.ExecuteReader().HasRows;
                        con.Close();
                    }
                }
            }
            else
            {
                query = "Insert Into Cart";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        con.Open();
                        isRow = cmd.ExecuteReader().HasRows;
                        con.Close();
                    }
                }
            }
        }
    }
}