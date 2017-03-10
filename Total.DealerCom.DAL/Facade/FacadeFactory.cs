using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class FacadeFactory : IFacadeFactory
    {
        #region IFacadeFactory Members

        public IUserFacade GetUserFacade()
        {
            return new UserFacade();
        }

        public IVideoFacade GetVideoFacade()
        {
            return new VideoFacade();
        }

        public ILookupFacade GetLookupFacade()
        {
            return new LookupFacade();
        }

        public IArticleFacade GetArticleFacade()
        {
            return new ArticleFacade();
        }

        public IIssueFacade GetIssueFacade()
        {
            return new IssueFacade();
        }

        public IGroupFacade GetGroupFacade()
        {
            return new GroupFacade();
        }

        public ILogFacade GetLogFacade()
        {
            return new LogFacade();
        }

        public IQuestionnaireFacade GetQuestionnaireFacade()
        {
            return new QuestionnaireFacade();
        }

        public IEmailFacade GetEmailFacade()
        {
            return new EmailFacade();
        }

        //public IUserRoleService GetUserRoleService()
        //{
        //    return new UserRoleService();
        //}

        public IDealerFacade GetDealerFacade()
        {
            return new DealerFacade();
        }

        public IFAQFacade GetFAQFacade()
        {
            return new FAQFacade();
        }

        public IRequesterFacade GetRequesterFacade()
        {
            return new RequesterFacade();
        }

        public ISupplierFacade GetSupplierFacade()
        {
            return new SupplierFacade();
        }

        public ISupplierMasterDataFacade GetSupplierMasterDataFacade()
        {
            return new SupplierMasterDataFacade();
        }

       public ISupplierProductFacade GetSupplierProductFacade()
        {
            return new SupplierProductFacade();
        }

       public IProvinceFacade GetProvinceFacade()
       {
           return new ProvinceFacade();
       }

       public IRangingFacade GetRangingFacade()
       {
           return new RangingFacade();
       }

       public IMasterDataStatusFacade GetMasterDataStatusFacade()
       {
           return new MasterDataStatusFacade();
       }

       public ISupplierStagingFacade GetSupplierStagingFacade()
       {
           return new SupplierStagingFacade();
       }

       public ISupplierProductStagingFacade GetSupplierProductStagingFacade()
       {
           return new SupplierProductStagingFacade();
       }

       public IRequesterStagingFacade GetRequesterStagingFacade()
       {
           return new RequesterStagingFacade();
       }

        public IGeneralChangesFacade GetGeneralChangesFacade()
        {
            return new GeneralChangesFacade();
        }

        public IGeneralChangesLinkFacade GetGeneralChangesLinkFacade()
        {
            return new GeneralChangesLinkFacade();
        }

        public IGeneralChangesRequestFacade GetGeneralChangesRequestFacade()
        {
            return new GeneralChangesRequestFacade();
        }

        public IRecipesRequestFacade GetRecipesRequestFacade()
        {
            return new RecipesRequestFacade();
        }

        public IRecipesItemFacade GetRecipesItemFacade()
        {
            return new RecipesItemFacade();
        }

        public IMailTemplateFacade GetMailTemplateFacade()
        {
            return new MailTemplateFacade();
        }

        #endregion
    }
}
