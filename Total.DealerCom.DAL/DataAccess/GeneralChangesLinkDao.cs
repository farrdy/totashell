using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    public static class GeneralChangesLinkDao
    {
        public static GeneralChangesLink Create(GeneralChangesLink link)
        {
            var dr = DataFacade.GetDataRow("GeneralChangesLinkCreate",
                                           new ParameterValue("GeneralChangesRequestId", link.GeneralChangesRequest.Id),
                                           new ParameterValue("GeneralChangesItemId", link.GeneralChangesItem.Id),
                                           new ParameterValue("IsSelected", link.IsSelected),
                                           new ParameterValue("Comments", link.Comments),
                                           new ParameterValue("Approved", link.Approved)
                );

            return dr != null
                       ? new GeneralChangesLink
                           {
                               Id = (int)dr["Id"],
                               GeneralChangesRequest = link.GeneralChangesRequest,
                               GeneralChangesItem = link.GeneralChangesItem,
                               IsSelected = (bool)dr["IsSelected"],
                               Comments = dr["Comments"].ToString(),
                               Approved = dr["Approved"] as bool?,
                               MasterDataApproved = dr["MasterDataApproved"] as bool?,
                               SpecialistVerificationApproved = dr["SpecialistVerificationApproved"] as bool?
                           }
                       : null;
        }

        public static GeneralChangesLink Update(GeneralChangesLink link)
        {
            var dr = DataFacade.GetDataRow("GeneralChangesLinkUpdate",
                                           new ParameterValue("Id", link.Id),
                                           new ParameterValue("GeneralChangesRequestId", link.GeneralChangesRequest.Id),
                                           new ParameterValue("GeneralChangesItemId", link.GeneralChangesItem.Id),
                                           new ParameterValue("IsSelected", link.IsSelected),
                                           new ParameterValue("Comments", link.Comments),
                                           new ParameterValue("Approved", link.Approved),
                                           new ParameterValue("SpecialistVerificationApproved", link.SpecialistVerificationApproved),
                                           new ParameterValue("SpecialistVerificationStatusDateTime", link.SpecialistVerificationStatusDateTime),
                                           new ParameterValue("MasterDataApproved", link.MasterDataApproved),
                                           new ParameterValue("MasterDataStatusDateTime", link.MasterDataStatusDateTime)
                );

            return dr != null
                       ? new GeneralChangesLink
                       {
                           Id = (int)dr["Id"],
                           GeneralChangesRequest = link.GeneralChangesRequest,
                           GeneralChangesItem = link.GeneralChangesItem,
                           IsSelected = (bool)dr["IsSelected"],
                           Comments = dr["Comments"].ToString(),
                           Approved = dr["Approved"] as bool?,
                           MasterDataApproved = dr["MasterDataApproved"] as bool?,
                           SpecialistVerificationApproved = dr["SpecialistVerificationApproved"] as bool?
                       }
                       : null;
        }
    }
}
