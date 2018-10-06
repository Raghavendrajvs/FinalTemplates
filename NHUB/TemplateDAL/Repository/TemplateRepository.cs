using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDAL.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TemplateDAL.Repository
{
    public class TemplateRepository
    {

        public List<TemplateProp> templateProps = new List<TemplateProp>();
        public List<TemplateProp> templatevent = null;
        public List<TemplateProp> template = null;
        public void getDetails()
        {


            string sql = "select * from Source  ";
            using (SqlCommand templateCommand = new SqlCommand(sql, ConnectionOpen()))
            {
                // DataSet templateStore = new DataSet();
                //templateAdapter.Fill(templateStore);
                SqlDataReader templateReader = templateCommand.ExecuteReader();
                while (templateReader.Read())
                {
                    templateProps.Add(new TemplateProp
                    {
                        SourceId = Convert.ToInt32(templateReader["Id"]),
                        SourceName = templateReader["Name"].ToString(),

                    });
                }

            }
        }
        public void getDetails1(int SourceId)
        {
            templatevent = new List<TemplateProp>();
            string EventName = "select * from Event where SourceId=" + SourceId;
            using (SqlCommand templateCommand = new SqlCommand(EventName, ConnectionOpen()))
            {
                // DataSet templateStore = new DataSet();
                //templateAdapter.Fill(templateStore);
                SqlDataReader templateReader = templateCommand.ExecuteReader();
                while (templateReader.Read())
                {
                    templatevent.Add(new TemplateProp
                    {
                        EventId = Convert.ToInt32(templateReader["Id"]),
                        EventName = templateReader["Name"].ToString(),

                    });
                }

            }
        }
        public void getDetails2(int EventId, int sourceId)
        {
            template = new List<TemplateProp>();
            string templateName = "select distinct(t.Name), t.Id from Template t,  Event e where t.EventId=" + EventId+ "and e.SourceId = "+sourceId ;
            using (SqlCommand templateCommand = new SqlCommand(templateName, ConnectionOpen()))
            {
                // DataSet templateStore = new DataSet();
                //templateAdapter.Fill(templateStore);
                SqlDataReader templateReader = templateCommand.ExecuteReader();
                while (templateReader.Read())
                {
                    template.Add(new TemplateProp
                    {
                        Id = Convert.ToInt32(templateReader["Id"]),
                        Name = templateReader["Name"].ToString(),

                    });
                }

            }


        }
    

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=ACUPC_120;Initial Catalog=NotificationHub;Integrated Security=True";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }

                }
                return dt;
            }

        }

        public SqlConnection con = null;
        public SqlConnection ConnectionOpen()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=ACUPC_120;Initial Catalog=NotificationHub;Integrated Security=True";
            con.Open();
            return con;
        }

       public SqlConnection connectionClose()
       {
           con.Close();
            return con;
        }

        public int ServiceLineID(string ServiceLineName)
        {
            int SLN = 0;
            string SLNquery = "select Id from ServiceLine where Name='" + ServiceLineName + "'";
            using (SqlCommand ServicelineIdCommand1 = new SqlCommand(SLNquery, ConnectionOpen()))
            {
                SqlDataReader ServiceReader1 = ServicelineIdCommand1.ExecuteReader();
                while (ServiceReader1.Read())
                {
                    SLN = Convert.ToInt32(ServiceReader1["Id"].ToString());
                }
                connectionClose();
            }
            return SLN;
        }
        int EventId = 0;
        public int EventID(string EventName)
        {
           string ENquery = "select Id from Event where Name='" + EventName + "'";
           using (SqlCommand ServicelineIdCommand2 = new SqlCommand(ENquery, ConnectionOpen()))
           {
                SqlDataReader ServiceReader2 = ServicelineIdCommand2.ExecuteReader();
                while (ServiceReader2.Read())
                {
                    EventId = Convert.ToInt32(ServiceReader2["Id"].ToString());
                }
                connectionClose();
            }
            return EventId;
        }
        int ChannelId = 0;
        public int ChannelID(string ChannelName)
        {
            string CNquery = "select Id from Channel where Name='" + ChannelName + "'";
            using (SqlCommand ServicelineIdCommand3 = new SqlCommand(CNquery, ConnectionOpen()))
            {
                SqlDataReader ServiceReader3 = ServicelineIdCommand3.ExecuteReader();
                while (ServiceReader3.Read())
                {
                    ChannelId = Convert.ToInt32(ServiceReader3["Id"].ToString());
                }
                connectionClose();
            }
            return ChannelId;
        }
    
        public void Create(string Name, string OperationaManagerId, string ServiceLineName, string EventName)
        {
            string sql = "Insert Into Template " +
                        "( Name, OperationManagerId, ServiceLineId, EventId, ApprovalStatusId) Values " +
                        "( @Name, @OperationManagerId, @ServiceLineId, @EventId, @ApprovalStatusId)";

            using (SqlCommand command = new SqlCommand(sql, ConnectionOpen()))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = Name,
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@OperationManagerId",
                   Value = OperationaManagerId,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ServiceLineId",
                    Value = ServiceLineID(ServiceLineName),
                    SqlDbType = SqlDbType.Int,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@EventId",
                    Value = EventID(EventName),
                    SqlDbType = SqlDbType.Int,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ApprovalStatusId",
                    Value = 1,
                   SqlDbType = SqlDbType.Int,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();

                connectionClose();

            }

        }

       public void Delete(int Id)

       {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=ACUPC_120;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                // Get ID of car to delete, then do so.
                string sql = $"Delete from Template where Id = '{Id}'";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                       cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Sorry! Error!", ex);
                        throw error;
                    }
                }
                connection.Close();
            }
        }

        //public void getdetails()
        //{

        //}

    }
}
