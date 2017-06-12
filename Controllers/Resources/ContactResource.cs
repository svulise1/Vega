using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace vega.Controllers.Resources
{
 
        public class ContactResource
        {
        [Required]
            public string ContactName { get; set; }

            public  string ContactEmail { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        }
    }

