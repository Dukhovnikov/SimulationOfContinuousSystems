using System;

namespace SCS.Core
{
    public class OptLogic
    {
        public void Run(IRegistry registry)
        {
            var calclationService = registry.CalculationService;
            var cslculationRepository = registry.CalculationRepository;
            var staticDataRepository = registry.StaticDataRepository;
            var showDataToUserService = registry.ShowDataToUserService;
            
            var fitnessFunction = staticDataRepository.GetFitnessFunctionMethod();

            calclationService.SetFitnessFunctionMethod(fitnessFunction);
            calclationService.SetRepository(cslculationRepository);

            var dataPoints = calclationService.Calculate();
            showDataToUserService.ShowPoints(dataPoints);

        }
    }

    public interface IRegistry
    {
        ICalculationRepository CalculationRepository { get; set; }
        ICalculationService CalculationService { get; set; }
        IStaticDataRepository StaticDataRepository { get; set; }
        IShowDataToUserService ShowDataToUserService { get; set; }
    }

    public interface IShowDataToUserService
    {
        void ShowPoints(IDataPoints dataPoints);
    }

    public interface IStaticDataRepository
    {
        Func<IDataPoints> GetFitnessFunctionMethod();
    }
}