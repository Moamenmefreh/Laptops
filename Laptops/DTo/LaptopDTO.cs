using Laptops.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Laptops.DTo
{
    public class LaptopDTO
    {
        public int Id { get; set; }

        public string laptopName { get; set; } = null;
        public string Color { get; set; } = null;
      
        public int Price { get; set; }



        public int processorId { get; set; }

        public int ramId { get; set; }
        public int storageId { get; set; }


    }
}
