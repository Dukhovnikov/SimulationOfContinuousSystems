using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SCS.ConsoleApp.Implementation;
using SCS.Core;

namespace SCS.ConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var circuit = new Circuit();

            var elements = new Collection<Element>()
            {
                new Element()
                {
                    In = 1,
                    Out = 2,
                    Name = "R3",
                    Type = ElementType.Resistor,
                    Value = 10
                },
                new Element()
                {
                    In = 1,
                    Out = 0,
                    Name = "R2",
                    Type = ElementType.Resistor,
                    Value = 15
                },
                new Element()
                {
                    In = 2,
                    Out = 0,
                    Name = "J2",
                    Type = ElementType.CurrentSource,
                    Value = 10
                },
                new Element()
                {
                    In = 1,
                    Out = 2,
                    Name = "J1",
                    Type = ElementType.CurrentSource,
                    Value = 12
                }
            };
        }
    }
}