using CollegeProject.Models;
using System.Data.SqlClient;

namespace CollegeProject.RepoClass
{
    public class VendorDashServices
    {
        private IConfiguration _configuration;
        public VendorDashServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Connection()
        {
            var constr = _configuration.GetConnectionString("Dbss");
            return constr;
        }

        public List<AgentTaskModel> GetVendorKoList(AgentTaskModel vendor)
        {
            using(SqlConnection con = new SqlConnection(Connection()))
            {
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType =System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "");
                cmd.Parameters.AddWithValue("@CompanyId",);
                SqlDataReader rdr=cmd.ExecuteReader();

                while (rdr.Read())
                {
                    AgentTaskModel model = new AgentTaskModel();
                    model.OrderId = rdr["OrderId"].ToString();
                    model.CustomerName = rdr["Cust_Name"].ToString();
                    model.CustomerAddress = rdr["Cust_Address"].ToString();
                    model.CustomerPhone = rdr["Cust_Phone"].ToString();
                    model.ReceiverAgentName = rdr[""].ToString();
                    model.ReceiverAgentPhone = rdr[""].ToString();
                    model.DeliveryAgentName = rdr[""].ToString();
                    model.DeliveryAgentPhone = rdr[""].ToString();
                    model.DeliveryStatus = rdr[""].ToString();
                }
            }

        }

    }
}
