using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
//using Repository;
//using Total.DealerClassification.BusinessLogic;
//using Total.DealerClassification.Repository;
//using Total.DealerCom.DataAccessLayer.BLL;
//using Total.DealerClassification.ServicesLayer.BLL.FileDecoders;
//using Total.DealerCom.DataAccessLayer.BLL.Interfaces;
//using Total.DealerCom.DataAccessLayer.BLL.Validation;

using Microsoft.Practices.Unity.ServiceLocatorAdapter;
using Total.DealerCom.DataAccessLayer.Facade;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using Total.DealerCom.DataAccessLayer.Infrastructure;
using Total.DealerCom.DataAccessLayer.Infrastructure.Interfaces;
//using Total.DealerClassification.ServicesLayer.Repository;
//using Total.DealerClassification.ServicesLayer.Repository.Interfaces;
//using Total.DealerClassification.ServicesLayer.Utility;
//using Total.DealerClassification.ServicesLayer.Utility.Interfaces;
using Unity.LifeTimeContainers;

namespace Total.DealerCom.DataAccessLayer
{
    public static class BootStrap
    {
        public static void Initialise()
        {
            IUnityContainer container = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new Microsoft.Practices.Unity.ServiceLocatorAdapter.UnityServiceLocator(container));

            //// Create this once for the web session
            //container.RegisterType<IInfrastructure, Infrastructure.Infrastructure>(
            //  new SessionLifetimeManager<IInfrastructure>());

            //container.RegisterType<IInfrastructure, Infrastructure>(); // Create per request (call to object)

            // Create this once for the web session
            ////container.RegisterType<ICache, CachingAsp>(new SessionLifetimeManager<ICache>());
            // Can be replaced with CachingNull if we want to turn caching off
            container.RegisterType<IConfig, Config>(new SessionLifetimeManager<IConfig>());
            container.RegisterType<IFacadeFactory, FacadeFactory>();

            // Service Layer
            //container.RegisterType<IDealerFacade, DealerFacade>();
            //container.RegisterType<IOperationTypeFacade, OperationTypeFacade>();
            //container.RegisterType<ISecurityFacade, SecurityFacade>();
            //container.RegisterType<IFileFacade, FileFacade>();
            //container.RegisterType<IAttendanceFacade, AttendanceFacade>();
            //container.RegisterType<ITopServiceFacade, TopServiceFacade>();
            //container.RegisterType<ISalesVolumeFacade, SalesVolumeFacade>();
            //container.RegisterType<ISalesTargetFacade, SalesTargetFacade>();
            //container.RegisterType<IAccountManagementFacade, AccountManagementFacade>();
            //container.RegisterType<IUnpaidsFacade, UnpaidsFacade>();
            //container.RegisterType<IRentReceivableFacade, RentReceivableFacade>();
            //container.RegisterType<ISystemParameterFacade, SystemParameterFacade>();
            //container.RegisterType<IRatingFacade, RatingFacade>();
            //container.RegisterType<ICreditRatingFacade, CreditRatingFacade>();
            //container.RegisterType<IScorecardFacade, ScorecardFacade>();
            //container.RegisterType<IBenefitParameterFacade, BenefitParameterFacade>();
            //container.RegisterType<ISalesAreaFacade, SalesAreaFacade>();

            // Business Layer
            //container.RegisterType<IValidator, VABValidator>();
            //container.RegisterType<IDealerBll, DealerBll>();
            //container.RegisterType<IOperationTypeBll, OperationTypeBll>();
            //container.RegisterType<ISecurityBll, SecurityBll>();
            //container.RegisterType<IFileBll, FileBll>();
            //container.RegisterType<ITopServiceDecoder, TopServiceDecoder>();
            //container.RegisterType<ISalesVolumeDecoder, SalesVolumeDecoder>();
            //container.RegisterType<ISalesTargetDecoder, SalesTargetDecoder>();
            //container.RegisterType<IAttendanceDecoder, AttendanceDecoder>();
            //container.RegisterType<IAccountManagementDecoder, AccountManagementDecoder>();
            //container.RegisterType<IDealerDecoder, DealerDecoder>();
            //container.RegisterType<IUnpaidsDecoder, UnpaidsDecoder>();
            //container.RegisterType<IRentReceivableDecoder, RentReceivableDecoder>();
            //container.RegisterType<IAttendanceBll, AttendanceBll>();
            //container.RegisterType<ITopServiceBll, TopServiceBll>();
            //container.RegisterType<ISalesVolumeBll, SalesVolumeBll>();
            //container.RegisterType<ISalesTargetBll, SalesTargetBll>();
            //container.RegisterType<IAccountManagementBll, AccountManagementBll>();
            //container.RegisterType<IUnpaidsBll, UnpaidsBll>();
            //container.RegisterType<IRentReceivableBll, RentReceivableBll>();
            //container.RegisterType<ISystemParameterBll, SystemParameterBll>();
            //container.RegisterType<IRatingBll, RatingBll>();
            //container.RegisterType<ICreditRatingBll, CreditRatingBll>();
            //container.RegisterType<IScorecardBll, ScorecardBll>();
            //container.RegisterType<IBenefitParameterBll, BenefitParameterBll>();
            //container.RegisterType<ISalesAreaBll, SalesAreaBll>();

            // Data Layer
            //container.RegisterType<IDealerRepository, DealerRepository>();
            //container.RegisterType<IOperationTypeRepository, OperationTypeRepository>();
            //container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<IFunctionRepository, FunctionRepository>();
            //container.RegisterType<IUserFunctionRepository, UserFunctionRepository>();
            //container.RegisterType<IFileHistoryRepository, FileHistoryRepository>();
            //container.RegisterType<ITopServiceStagingRepository, TopServiceStagingRepository>();
            //container.RegisterType<ISalesVolumeStagingRepository, SalesVolumeStagingRepository>();
            //container.RegisterType<ISalesTargetStagingRepository, SalesTargetStagingRepository>();
            //container.RegisterType<IAttendanceStagingRepository, AttendanceStagingRepository>();
            //container.RegisterType<IAccountManagementStagingRepository, AccountManagementStagingRepository>();
            //container.RegisterType<IDealerStagingRepository, DealerStagingRepository>();
            //container.RegisterType<IUnpaidsStagingRepository, UnpaidsStagingRepository>();
            //container.RegisterType<IRentReceivableStagingRepository, RentReceivableStagingRepository>();
            //container.RegisterType<IAuditRepository, AuditRepository>();
            //container.RegisterType<IAttendanceRepository, AttendanceRepository>();
            //container.RegisterType<ITopServiceRepository, TopServiceRepository>();
            //container.RegisterType<ISalesVolumeRepository, SalesVolumeRepository>();
            //container.RegisterType<ISalesTargetRepository, SalesTargetRepository>();
            //container.RegisterType<IAccountManagementRepository, AccountManagementRepository>();
            //container.RegisterType<IUnpaidsRepository, UnpaidsRepository>();
            //container.RegisterType<IRentReceivableRepository, RentReceivableRepository>();
            //container.RegisterType<ISystemParameterRepository, SystemParameterRepository>();
            //container.RegisterType<IRatingRepository, RatingRepository>();
            //container.RegisterType<IRatingTypeRepository, RatingTypeRepository>();
            //container.RegisterType<ICurrentRatingViewRepository, CurrentRatingViewRepository>();
            //container.RegisterType<IScorecardRepository, ScorecardRepository>();
            //container.RegisterType<IScorecardViewRepository, ScorecardViewRepository>();
            //container.RegisterType<IScorecardBenefitRepository, ScorecardBenefitRepository>();
            //container.RegisterType<IDealerRatingTypeRepository, DealerRatingTypeRepository>();
            //container.RegisterType<IDealerRatingTypeHistoryRepository, DealerRatingTypeHistoryRepository>();
            //container.RegisterType<IBenefitParameterRepository, BenefitParameterRepository>();
            //container.RegisterType<ICurrentBenefitParameterViewRepository, CurrentBenefitParameterViewRepository>();
            //container.RegisterType<ISalesAreaRepository, SalesAreaRepository>();

            // Utility
            //container.RegisterType<IEmailClient, EmailClient>();

            // Can do this for our 
            //container.RegisterType<IDataContextFactory, DataContextFactory>();
            //container.RegisterType<DataContext, DealerClassificationDataContext>();
            // NB : Tell Unity to use the Default Constructor! LINQ provides several other constructors
            //container.Configure<InjectedMembers>()
            //  .ConfigureInjectionFor<DealerClassificationDataContext>(new InjectionConstructor());

            // But not for the instance LINQ data context - ... No Interface?
            // container.RegisterType<IDataContext, DataContext>();

            /* You cannot use the lifetime managers with the name grouping unless we change the life time manager to take the grouing as well. 
                  container.RegisterType<IDealer, FacadeDealer>("a", new SessionLifetimeManager<ILogger>());
                  container.RegisterType<IDealer, FacadeDealer2>("b", new SessionLifetimeManager<ILogger>());
                  */
        }
    }
}