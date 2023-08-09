using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
