
namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// Facade factory used to retrieve instances of another facade
    /// </summary>
    public interface IFacadeFactory
    {
        IUserFacade GetUserFacade();

        ILookupFacade GetLookupFacade();

        IArticleFacade GetArticleFacade();

        IVideoFacade GetVideoFacade();

        IGroupFacade GetGroupFacade();

        IQuestionnaireFacade GetQuestionnaireFacade();

        IEmailFacade GetEmailFacade();

        ILogFacade GetLogFacade();

        IIssueFacade GetIssueFacade();

        IDealerFacade GetDealerFacade();

        IFAQFacade GetFAQFacade();

        IRequesterFacade GetRequesterFacade();

        ISupplierFacade GetSupplierFacade();

        ISupplierMasterDataFacade GetSupplierMasterDataFacade();

        ISupplierProductFacade GetSupplierProductFacade();

        IProvinceFacade GetProvinceFacade();

        IRangingFacade GetRangingFacade();

        IMasterDataStatusFacade GetMasterDataStatusFacade();

        ISupplierStagingFacade GetSupplierStagingFacade();

        ISupplierProductStagingFacade GetSupplierProductStagingFacade();

        IRequesterStagingFacade GetRequesterStagingFacade();

        IGeneralChangesFacade GetGeneralChangesFacade();

        IGeneralChangesLinkFacade GetGeneralChangesLinkFacade();

        IGeneralChangesRequestFacade GetGeneralChangesRequestFacade();

        IRecipesRequestFacade GetRecipesRequestFacade();

        IRecipesItemFacade GetRecipesItemFacade();

        IMailTemplateFacade GetMailTemplateFacade();
    }
}
