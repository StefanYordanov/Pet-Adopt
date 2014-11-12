using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models.Common
{
    public interface IOrderable
    {
        int OrderBy { get; set; }
    }
}
