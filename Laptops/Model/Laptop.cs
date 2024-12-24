using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Laptops.Model
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        public string laptopName { get; set; } = null;
        public string Color { get; set; } = null;
        public int Price { get; set; }
       
        [ForeignKey(nameof(Processor))]
        public int processorId { get; set; }
        [JsonIgnore]
        public Processor? Processor { get; set; }
        [ForeignKey(nameof(Ram))]
        public int ramId { get; set; }
        [JsonIgnore]
        public Ram? Ram { get; set; }
        [ForeignKey(nameof(Storage))]
        public int storageId { get; set; }
        [JsonIgnore]
        public Storage? Storage { get; set; }
        [JsonIgnore]
        public IEnumerable<User> users { get; set; }
        
    }
}
