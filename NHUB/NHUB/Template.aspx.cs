using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemplateDAL.Repository;
using System.Data;
using System.Data.SqlClient;


namespace NHUB
{
    public partial class Template : System.Web.UI.Page
    {

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    if (!Page.IsPostBack)
        //    {
        //        Table t = new Table();
        //        t.ID = "1";
        //        PlaceHolder1.Controls.Add(t);
        //        TemplateRepository tr = new TemplateRepository();
        //        tr.getDetails();


        //        for (int count = 0; count < tr.templateProps.Count(); count++)
        //        {
        //            TableRow tableRow = new TableRow();
        //            t.Rows.Add(tableRow);
        //            TableCell tcell = new TableCell();
        //            //PlaceHolder placeHolder = new PlaceHolder();
        //            Label lb = new Label();

        //            lb.Width = 200;
        //            PlaceHolder1.Controls.Add(lb);

        //            HyperLink Configure = new HyperLink();
        //            HyperLink Delete = new HyperLink();
        //            Configure.Text = "Configure";
        //            Configure.NavigateUrl = "AddTemplates.aspx";
        //            Configure.Width = 200;
        //            PlaceHolder1.Controls.Add(Configure);
        //            Delete.Text = "Delete";
        //            Delete.NavigateUrl = "Delete.aspx";
        //            Delete.Width = 200;
        //            PlaceHolder1.Controls.Add(Delete);
        //            tableRow.Cells.Add(tcell);
        //        }
        //    }



        //}
        TemplateRepository ts = new TemplateRepository();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!this.IsPostBack)
            { 
               
                DataTable dt = ts.GetData("SELECT Id, Name FROM Source");
                //DataTable dt1 = ts.GetData("SELECT Id, Name FROM Event");
                
                this.PopulateTreeView(dt, 0, null);
               // this.PopulateTreeView1(dt1, 0, null);

               
                
            }
        }

        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treenode)
        {
            int id = 0;
            foreach (DataRow row in dtParent.Rows)
            {

                
                TreeNode child = new TreeNode
                {

                    Text = row["Name"].ToString(),
                    Value = row["Id"].ToString()
                    
                };
              
                if (parentId == 0)
                {

                    
                    TreeView1.Nodes.Add(child);
                    
                    DataTable dtChild = ts.GetData("SELECT Id, Name FROM Event WHERE SourceId = " + child.Value);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                    // //DataTable dt1Child = ts.GetData("SELECT Id, Name FROM Template WHERE EventId = " + subchild.Value);
                    DataTable dtsubchild = ts.GetData("select e.Id, e.Name from Event e, Source s where e.SourceId = s.Id and s.Id=" + child.Value);
                    PopulateTreeViewChild(dtsubchild, 0, null);
                    
                }
                else
                {

                    //treenode.ChildNodes.Add(child);
                    // //DataTable dt2 = ts.GetData("select t.EventId , ev.Name from Template t, Event ev where ev.Id = t.EventId");
                    // DataTable dtsubchild = ts.GetData("select e.Id, e.Name from Event e, Source s where e.SourceId = s.Id and s.Id=" + child.Value);
                     // PopulateTreeViewChild(dtsubchild, 0, null);
                   
                }

            }
        }
        HyperLink Configure;
        HyperLink Delete;
        private void PopulateTreeViewChild(DataTable dt1Parent, int parentId, TreeNode treenode)
        {
            foreach (DataRow row in dt1Parent.Rows)
            {

                TreeNode subchild = new TreeNode
                {
                    Text = row["Name"].ToString(),
                    Value = row["Id"].ToString()
                    
                };
              
                if (parentId == 0)
                {
                   

                    TreeView1.Nodes.Add(subchild);
                    subchild.Text += "-----------Event";

                    //DataTable dtChild = ts.GetData("SELECT Id, Name FROM Event WHERE SourceId = " + child.Value);
                    DataTable dt1Child = ts.GetData("SELECT Id, Name FROM Template WHERE EventId = " + subchild.Value);
                    PopulateTreeViewChild(dt1Child, int.Parse(subchild.Value), subchild);
                    
                        
                }
                else
                {
                    
                        treenode.ChildNodes.Add(subchild);
                    subchild.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                   "Configure" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                   "Delete";
                }

            }
        }


       


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTemplates.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
            //if (!Page.IsPostBack)
            //{
            //    using (SqlConnection Conn = new SqlConnection())
            //    {
            //        Conn.ConnectionString = "Data Source=ACUPC_120;Initial Catalog=NotificationHub;Integrated Security=True";
            //        Conn.Open();

            //        string Source = "Select * from Source";
            //        string Event = "Select * from Event";
            //        //string Template = "select * from Template";

            //        string Treeview = Source + ";" + Event /*+ ";" + Template*/;

            //        DataSet ds = new DataSet();
            //        SqlDataAdapter da = new SqlDataAdapter(Treeview, Conn);
            //        da.Fill(ds);
            //        ds.Tables[0].TableName = "Source";
            //        ds.Tables[1].TableName = "Event";
            //        //ds.Tables[2].TableName = "Template";

            //        DataRelation dr = new DataRelation("SourceEvent", ds.Tables["Source"].Columns["Id"], ds.Tables["Event"].Columns["E_Id"]);
            //        ds.Relations.Add(dr);

            //        foreach (DataRow drSource in ds.Tables["Source"].Rows)
            //        {
            //            TreeNode NDSource = new TreeNode();
            //            NDSource.Text = drSource["Name"].ToString();
            //            NDSource.Value = drSource["Id"].ToString();
            //            TreeView1.Nodes.Add(NDSource);

            //            foreach (DataRow drEvent in drSource.GetChildRows("SourceEvent"))
            //            {
            //                TreeNode NDEvent = new TreeNode();
            //                NDEvent.Text = drEvent["E_Name"].ToString();
            //                NDEvent.Value = drEvent["E_Id"].ToString();
            //                NDSource.ChildNodes.Add(NDEvent);


            //            }
            //        }


            //DataRelation dr1 = new DataRelation("EventTemplate", ds.Tables["Event"].Columns["Id"], ds.Tables["Template"].Columns["Id"]);
            //ds.Relations.Add(dr1);

            //foreach (DataRow drEvent in ds.Tables["Event"].Rows)
            //{
            //    TreeNode NDEvent = new TreeNode();
            //    NDEvent.Text = drEvent["Name"].ToString();
            //    NDEvent.Value = drEvent["Id"].ToString();
            //    TreeView1.Nodes.Add(NDEvent);

            //    foreach (DataRow drTemplate in drEvent.GetChildRows("EventTemplate"))
            //    {
            //        TreeNode NDTemplate = new TreeNode();
            //        NDTemplate.Text = drTemplate["Name"].ToString();
            //        NDTemplate.Value = drTemplate["Id"].ToString();
            //        NDTemplate.ChildNodes.Add(NDEvent);


            //    }
            //}



            //DataRelation dr = new DataRelation("SourceEventTemplate", ds.Tables["Source"].Columns["SourceId"], ds.Tables["Event"].Columns["EventId"],Convert.ToBoolean( ds.Tables["Template"].Columns["Id"]));
            //ds.Relations.Add(dr);

            //foreach (DataRow drSource in ds.Tables["Source"].Rows)
            //{
            //    TreeNode NDSource = new TreeNode();
            //    NDSource.Text = drSource["SourceName"].ToString();
            //    NDSource.Value = drSource["SourceId"].ToString();
            //    TreeView1.Nodes.Add(NDSource);

            //    foreach (DataRow drEvent in drSource.GetChildRows("SourceEvent"))
            //    {
            //        TreeNode NDEvent = new TreeNode();
            //        NDEvent.Text = drEvent["SourceName"].ToString();
            //        NDEvent.Value = drEvent["EventId"].ToString();
            //        NDSource.ChildNodes.Add(NDEvent);

            //        foreach (DataRow drTemplate in drEvent.GetChildRows("SourceEventTemplate"))
            //        {
            //            TreeNode NDTemplate = new TreeNode();
            //            NDTemplate.Text = drTemplate["Name"].ToString();
            //            NDTemplate.Value = drTemplate["Id"].ToString();
            //            NDEvent.ChildNodes.Add(NDTemplate);
            //        }
            //    }
            //}
            // }
            // }



            //string sourceConnection = "Data Source = ACUPC_120; Initial Catalog = NotificationHub; Integrated Security = True";
            //DataTable dtTree = new DataTable();
            //using (SqlConnection connection = new SqlConnection(sourceConnection))
            //{
            //    SqlCommand dbCommand = new SqlCommand();
            //    dbCommand.CommandText = "Select Id,Name from Source";
            //    dbCommand.CommandType = CommandType.Text;
            //    dbCommand.Connection = connection;
            //    SqlDataAdapter da = new SqlDataAdapter(dbCommand);
            //    da.Fill(dtTree);
            //    da.Dispose();
            //    dbCommand.Dispose();
            //    connection.Dispose();
            //}
            //AddNodes(-1, TreeView1.Nodes);


            //void AddNodes(int id, TreeNodeCollection tn)
            //{
            //    foreach (DataRow dr in dtTree.Select("Id = " + id))
            //    {
            //        TreeNode sub = new TreeNode(dr["Name"].ToString(), dr["Id"].ToString());
            //        tn.Add(sub);
            //        AddNodes(Convert.ToInt32(sub.Value), sub.ChildNodes);
            //    }
            //}
       //}







    }
}

