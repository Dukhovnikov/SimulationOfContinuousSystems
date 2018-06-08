using System.Collections.Generic;
using System.Linq;
using SCS.Core;

namespace SCS.ConsoleApp.Implementation
{
    public class Circuit : ICircuit
    {
        public ICollection<IElement> Elements { get; set; }
    }
}