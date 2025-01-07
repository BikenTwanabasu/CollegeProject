
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
                cmd.Parameters.AddWithValue("@AgentId", agentM.AgentId);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    AgentTaskModel agent = new AgentTaskModel();
                    agent.OrderId = rdr["OrderId"].ToString();
                    agent.VendorName = rdr["CompanyName"].ToString() ;
                    agent.VendorAddress = rdr["CompanyAddress"].ToString();
                    agent.VendorPhone = rdr["CompanyPhone"].ToString();
                    agent.CreatedDate = rdr["CreatedDate"].ToString();

                    agentTasksList.Add(agent);
                }
                return agentTasksList;
            }
        }
    }
}
