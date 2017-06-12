using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Core
{
    public interface IVechileRepo
    {
         Task<Vechile> GetVechile(int id, bool includeRelated = true);
        void AddVechile(Vechile Vechile);
        void RemoveVechile(Vechile vechile);
    } 
}
