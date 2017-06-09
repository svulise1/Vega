using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Models;
using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class VechileResource
    {

        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<int> Features { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
  
    }
}
