﻿using CollegeProject.Models;
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
        public bool RegisterVendor(Vendor vendor)
        {
            int i = 0;
            if (vendor.CompanyName == null && vendor.CompanyEmail == null) { return false; }

            
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName",vendor.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyAddress",vendor.CompanyAddress);
                cmd.Parameters.AddWithValue("@CompanyPhone",vendor.CompanyPhone);
                cmd.Parameters.AddWithValue("@CompanyEmail",vendor.CompanyEmail);
                cmd.Parameters.AddWithValue("@CompanyPassword",vendor.Password);
                cmd.Parameters.AddWithValue("@flag", "VendorRegistration");

                i = cmd.ExecuteNonQuery();
                return i > 0;
            }
            
        }

        public bool RegisterAgent(Agent agent)
        {
            int i = 0;
            if(agent.AgentEmail==null && agent.AgentPhone==null && agent.AgentAddress==null && agent.AgentPassword==null) 
            { return false; }


            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AgentName", agent.AgentName);
                cmd.Parameters.AddWithValue("@AgentEmail", agent.AgentEmail);
                cmd.Parameters.AddWithValue("@AgentPhone", agent.AgentPhone);
                cmd.Parameters.AddWithValue("@AgentAddress", agent.AgentAddress);
                cmd.Parameters.AddWithValue("@AgentPassword", agent.AgentPassword);
                cmd.Parameters.AddWithValue("@flag", "AgentRegistration");

                i = cmd.ExecuteNonQuery();
                return i > 0;
            }

        }
        public bool OrderCreations(OrderAndStudentModel orderAndStudentModel)
        {
            int i = 0;
            if (orderAndStudentModel==null )
            {
                return false; 
            }
            if (orderAndStudentModel.customer == null || orderAndStudentModel.order == null)
            {
                return false;
            }
          
           
            if (orderAndStudentModel.customer.CustomerName==null || orderAndStudentModel.customer.OrderReceiveDate == null || orderAndStudentModel.customer.Email==null || orderAndStudentModel.customer.CustomerAddress==null
                || orderAndStudentModel.order.DeliveryAddress==null || orderAndStudentModel.order.DeliveryDate==null || orderAndStudentModel.order.PaymentStatus==null )
            { return false; }


            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insertDatas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cust_Name",orderAndStudentModel.customer.CustomerName );
                cmd.Parameters.AddWithValue("@Cust_Address", orderAndStudentModel.customer.CustomerAddress);
                cmd.Parameters.AddWithValue("@Cust_Phone", orderAndStudentModel.customer.Phone);
                cmd.Parameters.AddWithValue("@Cust_Email", orderAndStudentModel.customer.Email);
                cmd.Parameters.AddWithValue("@CreatedDate", orderAndStudentModel.customer.OrderReceiveDate);
                cmd.Parameters.AddWithValue("@Amount", orderAndStudentModel.order.Amount);
                cmd.Parameters.AddWithValue("@PaymentStatus", orderAndStudentModel.order.PaymentStatus);
                cmd.Parameters.AddWithValue("@DeliveryAddress", orderAndStudentModel.order.DeliveryAddress);
                cmd.Parameters.AddWithValue("@DeliveryDate", orderAndStudentModel.order.DeliveryDate);
                
                cmd.Parameters.AddWithValue("@flag", "OrderCreation");

                i = cmd.ExecuteNonQuery();
                return i > 0;
            }

        }
    }
}