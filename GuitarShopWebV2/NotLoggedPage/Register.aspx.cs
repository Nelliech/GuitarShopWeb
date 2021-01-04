using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuitarShopWebV2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            var name = NameTextBox.Text;
            var surname = SurnameTextBox.Text;
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            string query = "Insert Into ApplicationUser Values(@name, @surname, @login, @password, @typeAccount)";
            if (!IsUser(login))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@surname", surname);
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@typeAccount", "User");
                         
                        con.Open();
                        int o = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            else
            {
                SingInLabel.Visible = true;
            }
        }

        public bool IsUser(string login)
        {
            var query = "SELECT Login From ApplicationUser Where Login = @login";
            string connectionString = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            bool isUser;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                         isUser = reader.Read();
                    }
                }
                con.Close();
                
            }
            return isUser;
        }
    }
}