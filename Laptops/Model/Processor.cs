using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Laptops.Model
{
    public class Processor
    {
        [Key]
        public int processorId { get; set; }
        public string Model { get; set; }
        public string Name {  get; set; }
        [JsonIgnore]
        public Laptop? Laptop { get; set; }

    }
}
