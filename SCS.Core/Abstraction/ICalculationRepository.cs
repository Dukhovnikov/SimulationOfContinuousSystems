using SCS.Core.OptimizationMethods;

namespace SCS.Core
{
    public interface ICalculationRepository
    {
        Vector VariablesVector { get; set; }
        int InitialFrequency { get; set; }
        int FinalFrequency { get; set; }
        int Step { get; set; }
        void InitializeRepository(Vector variablesVector, int initialFrequency, int finalFrequency, int step);
    }
}