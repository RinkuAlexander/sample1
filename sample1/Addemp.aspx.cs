using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace sample1
{
    public partial class Addemp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=SYSLP1473\SQLEXPRESS;database=emp;Integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string str = "insert into tbl_emp1 values('" + txtname.Text + "','" + txtdes.Text + "','" + txtsalary.Text + "','" + txtplace.Text + "')";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i==1)
            {
                lblsubmit.Visible = true;
                lblsubmit.Text = "inserted";
            }
        }
    }
}