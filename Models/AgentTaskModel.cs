namespace CollegeProject.Models
{
    public class AgentTaskModel
    {
        public string? OrderId { get; set; }
        public string? VendorName { get; set; }
        public string? VendorAddress { get; set; }
        public string? VendorPhone { get; set; }   
        public DateOnly? CreatedDate { get; set; } 
        public string? DeliveryStatus { get; set; } 
    }
}
