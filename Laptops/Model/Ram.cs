using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Laptops.Model
{
    public class Ram
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public Laptop? Laptop { get; set; }

    }
}
