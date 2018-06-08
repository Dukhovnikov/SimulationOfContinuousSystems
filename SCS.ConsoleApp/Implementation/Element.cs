using SCS.Core;

namespace SCS.ConsoleApp.Implementation
{
    public class Element : IElement
    {
        public int In { get; set; }
        public int Out { get; set; }
        public string Name { get; set; }
        public ElementType Type { get; set; }
        public double Value { get; set; }
    }
}