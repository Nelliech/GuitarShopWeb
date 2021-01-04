using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuitarShopWebV2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {

            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;
            bool row;
            string connectionString = ConfigurationManager.ConnectionStrings["GuitarShopDBString"].ConnectionString;
            string query = "Select login, password From ApplicationUser Where Login=@login and Password =@password";
            if (!string.IsNullOrEmpty(login))
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        row=cmd.ExecuteReader().HasRows;
                        con.Close();
                    }
                }

                if (row)
                {
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(1, login,
                        DateTime.Now, //data i godzina założenia pliku cookie
                        DateTime.Now.AddMinutes(30), //czas wygaśnięcia
                        false, //czy cookie ma być trwałe
                        FormsAuthentication.FormsCookiePath); //adres strony
                    //umieszczenie biletu na zdalnym komputerze użytkownika
                    HttpCookie cookie = new HttpCookie(
                        FormsAuthentication.FormsCookieName,
                        FormsAuthentication.Encrypt(bilet));
                    Response.Cookies.Add(cookie);
                    Response.Redirect("~/LoggedPage/Shop.aspx");
                }
                
            }
            else
            {
                
            }
        }

        protected void RegisterLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}