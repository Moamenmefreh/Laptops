using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Laptops.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey(nameof(Laptop))]
        public int laptopId { get; set; } 
        [JsonIgnore]
        public Laptop? Laptop { get; set; }
    }
}
