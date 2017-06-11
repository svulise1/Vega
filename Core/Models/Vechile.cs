using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Models;

namespace Vega.Models
{
    [Table("Vechiles")]

    public class Vechile
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        public String ContactEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<VechileFeature> Features { get; set; }

        public  Vechile()
        {
            Features = new Collection<VechileFeature>();
        }
    }
}
