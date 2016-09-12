using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XepLenh
{
    public partial class CountDownJquery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var date_gh = date.AddHours(12);

            List<FuckDate> lst = new List<FuckDate>();
            for (var i = 0; i < 5; i++)
            {
                FuckDate o = new FuckDate() { CreateDate = date };

                lst.Add(o);
            }

            grvCountDown.DataSource = lst;
            grvCountDown.DataBind();
        }

        protected void grvCountDown_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ////Checking the RowType of the Row  
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //If Salary is less than 10000 than set the row Background Color to Cyan  
            //    if (Convert.ToInt32(e.Row.Cells[3].Text) < 10000)
            //    {
            //        e.Row.BackColor = Color.Cyan;
            //    }
            //} 

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ScriptManager.RegisterStartupScript(e.Row, e.Row.GetType(), e.Row.ClientID, "$('#" + e.Row.ClientID + "').countdown({ until: " + e.Row.Cells[1].Text + ", format: 'HMS' });", true);
                e.Row.BackColor = System.Drawing.Color.Cyan;

                Label lblcountdown = (Label) e.Row.FindControl("lblCountDown");
                Label lbldatecreate = (Label)e.Row.FindControl("lblCreateDate");

                DateTime datecreate = Convert.ToDateTime(lbldatecreate.Text);
                datecreate = datecreate.AddHours(10);

                string sScript = "$('#" + lblcountdown.ClientID + "').countdown({ until: '" + datecreate + "', format: 'HMS' });";
                //string sScript = "$('#" + lblcountdown.ClientID + "').countdown({ until: '" + datecreate.ToString() + "', format: 'dHM' });";

                ScriptManager.RegisterStartupScript(this, this.GetType(), lblcountdown.ClientID , sScript, true);
            } 
        }
    }

    class FuckDate
    {
        public DateTime? CreateDate { get; set; }
    }
}