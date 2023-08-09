using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models.Entity
{
    public class Admin : BaseEntity
    {
        public string? UserName { get; set; }    

        public string? UserPassword { get; set; }    

    }
}
