using System.Collections.Generic;
using System.Linq;

namespace SCS.Core
{
    public interface ICircuit
    {
        ICollection<IElement> Elements { get; set; }
        
        
    }
}