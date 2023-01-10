using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sample1
{
    public partial class viewemp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=SYSLP1473\SQLEXPRESS;database=emp;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fun_grid();
            }

        }
        public void  fun_grid() 
        {
            string s = "select * from tbl_emp1";
            DataSet ds= new DataSet();
            SqlDataAdapter da= new SqlDataAdapter(s,con);
            da.Fill(ds);
            GridView1.DataSource= ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = rw.Cells[4].Text;
            Label2.Text = rw.Cells[5].Text;

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i=e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from tbl_emp1 where emp_id=" + uid + "";
            SqlCommand cmd= new SqlCommand(del,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            fun_grid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex=e.NewEditIndex; 
            fun_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname1 = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtdes1= (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtsala= (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txtpla= (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            string sstr = "update tbl_emp1 set emp_name=" + txtname1.Text + ",designation=" + txtdes1.Text + ",salary=" + txtsala.Text + ",place=" + txtpla.Text + "where emp_id=" + uid + "";
            SqlCommand cmd=new SqlCommand(sstr,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();    
            GridView1.EditIndex= -1;
            fun_grid();
        }
    }
}