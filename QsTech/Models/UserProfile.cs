using System.ComponentModel.DataAnnotations;


namespace QsTech.Models
{
    public class UserProfile
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of User is Required!")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        
    }
}