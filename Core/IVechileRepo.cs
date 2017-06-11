using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Core
{
    public interface IVechileRepo
    {
         Task<Vechile> GetVechile(int id, bool Includerelated = true);
        void AddVechile(Vechile Vechile);
        void RemoveVechile(Vechile vechile);
    } 
}
