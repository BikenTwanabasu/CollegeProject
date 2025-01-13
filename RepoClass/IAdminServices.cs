using CollegeProject.Models;

namespace CollegeProject.RepoClass
{
    public interface IAdminServices
    {
        public List<AgentTaskModel> getAdminPresentList(AgentTaskModel model);
    }
}
