using CollegeProject.Models;
using System.Data.SqlClient;

namespace CollegeProject.RepoClass
{
    public class Services : IServices
    {
        private IConfiguration _configuration;

        public Services(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString()
        {
            string Constr=_configuration.GetConnectionString("Dbss");
            return Constr;
        }
        public bool InsertVendor(Vendor vendor)
        {
            int i=0;
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName",vendor.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyAddress",vendor.CompanyAddress);
                cmd.Parameters.AddWithValue("@CompanyPhone",vendor.CompanyPhone);
                cmd.Parameters.AddWithValue("@CompanyEmail",vendor.CompanyEmail);
                cmd.Parameters.AddWithValue("@flag", "VendorRegistration");

                i = cmd.ExecuteNonQuery();
            }
            return i>0;
        }
    }
}
