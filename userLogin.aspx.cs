using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ClaimInsurance
{
    public partial class userLogin : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        TextBox user, pass;
        Label mylab = new Label();
        string username, password;

      

        protected void Page_Load(object sender, EventArgs e)
        {     
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();

            if (IsUserActive(username, password))
            {

                bool validUser = userAuthentication(username, password);
                if (validUser)
                {
                    Response.Redirect("DashBoard.aspx");

                }
                
            }
            else
            {
                
                mylab.Text = "No Active user Found";
                this.Controls.Add(mylab);
            }
        }

        private bool userAuthentication(string username, string password)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Select @count = Count(*) from [dbo].[Users] where username=@username and password=@password", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            if (Convert.ToInt32(cmd.Parameters["@count"].Value) > 0)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            conn.Close();
            return success;
        }
        private bool IsUserActive(string username, string password)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Select @Active = Active from [dbo].[Users] where username=@username", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            success = (bool) cmd.Parameters["@Active"].Value;
            conn.Close();
            return success;
        }
    }



    
}
