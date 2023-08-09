namespace CustomerManagement.Models.DTO
{
    public class CustomerRegisterModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public DateTime Birthday { get; set; }  
        public string? Address { get; set; } 
        public string? Job { get; set; } 


    }
}
