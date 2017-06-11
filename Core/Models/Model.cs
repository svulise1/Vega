using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vega.Models
{
    [Table("Models")]
    public class Model
    {
        public  int Id { get; set; }
         [Required]
        [StringLength(255)]
        public string Name { get; set; } 
        public Make Make { get; set; }
        public int MakeId { get; set; }
        //Here it will not create a new coloumn. we need to follow the naming convention over here.
        //First name should be the class name and second one should be the property of that class.
        //Here MakeId act as Foreign key.

        
    }
}