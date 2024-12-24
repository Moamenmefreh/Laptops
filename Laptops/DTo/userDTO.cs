using System.ComponentModel.DataAnnotations;

namespace Laptops.DTo
{
    public class userDTO
    {
        public int userId { get; set; }
        public string FullNameAndAddress {  get; set; }
        public string Phone { get; set; }
        
        public string Email { get; set; }
        public string? laptopName { get; set; }
        
    }
}
