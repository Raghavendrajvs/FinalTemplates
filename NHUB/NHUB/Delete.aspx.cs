using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemplateDAL.Repository;

namespace NHUB
{
    public partial class Deletes : System.Web.UI.Page
    {
        string queryString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lb = new Label();
            lb.Text = "Are you sure to delete the template";
            PlaceHolder1.Controls.Add(lb);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            queryString = Request.QueryString["Id"];
            TemplateRepository tr = new TemplateRepository();
            tr.getDetails();
            tr.Delete(Convert.ToInt32(queryString));
            Response.Redirect("Template.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Template.aspx");
        }
    
    }
}