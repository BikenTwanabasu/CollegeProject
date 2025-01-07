
using CollegeProject.Models;
using CollegeProject.RepoClass;
using System.Data.SqlClient;

namespace collegeproject.repoclass
{
    public class agentdashservices: Iagentdashservices
    {
        private IConfiguration _configuration;
        public agentdashservices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Connection()
        {
            var constr = _configuration.GetConnectionString("Dbss");
            return constr;
        }

        public List<AgentTaskModel> GetAgentTask(AgentTaskModel agentM)
        {
            using (SqlConnection con = new SqlConnection(Connection()))
            {   List<AgentTaskModel> agentTasksList = new List<AgentTaskModel>();
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "AgentTaskPickupList");
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    agentM.OrderId = rdr["OrderId"].ToString();
                    agentM.VendorName = rdr["CompanyName"].ToString() ;
                    agentM.VendorAddress = rdr["CompanyAddress"].ToString();
                    agentM.VendorPhone = rdr["CompanyPhone"].ToString();
                    agentM.CreatedDate = (DateOnly)rdr["CreatedDate"];

                    agentTasksList.Add(agentM);
                }
                return agentTasksList;
            }
        }
    }
}
