namespace CustomerManagement.Models.DTO
{
    
   public class CustomerResponseModel
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
