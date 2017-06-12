using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vega.Models
{
   [Table("VechileFeatures")]
    public class VechileFeature
    {
        public int VechileId { get; set; }
        public int FeatureId { get; set; }
        public Vechile Vechile { get; set; }
        public Feature Feature { get; set; }
        //In oder to do composite api we need to impelnt fluent api

    }
}
