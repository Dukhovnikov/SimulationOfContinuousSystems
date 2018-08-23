using System;
using System.Collections.Generic;

namespace SCS.Core
{
    public interface ICalculationService
    {
        void SetFitnessFunctionMethod(Func<IDataPoints> fitnessFunctionMethod);
        void SetRepository(ICalculationRepository cslculationRepository);
        
        IDataPoints Calculate();
    }
}