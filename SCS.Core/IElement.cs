namespace SCS.Core
{
    public interface IElement
    {
        int In { get; set; }
        int Out { get; set; }
        string Name { get; set; }
        ElementType Type { get; set; }
        double Value { get; set; }
    }
}