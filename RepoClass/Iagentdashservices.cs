using CollegeProject.Models;

namespace CollegeProject.RepoClass
{
    public interface Iagentdashservices
    {
        public List<AgentTaskModel> GetAgentTask(AgentTaskModel agentM);
    }
}
