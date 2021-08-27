using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimInsurance
{
    public partial class LossTypeInformation : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            string query = @"SELECT LossTypeId,LossTypeCode,LossTypeDescription,Active,  
               LastUpdatedDate,LastUpdatedId,CreatedDate,CreatedId FROM LossTypes";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            //Populate Repeater control with data   
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}