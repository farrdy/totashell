using System.Collections.Generic;
using Total.DealerCom.Core;
using System.Web.UI.WebControls;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{

    public interface ILookupFacade
    {
        IEnumerable<Lookup> GetLookup(LookupSearch lookup);

        DropDownList Populate(ref DropDownList dropDownList, LookupSearch lookup, bool insertEmptyRow);


        List<string> PopulateUOM(ref DropDownList dropDownList);

        List<string> PopulateUOMType(ref DropDownList dropDownList);

        List<string> PopulateRanging(ref DropDownList dropDownList);
        
        void Edit(Lookup lookup);
    }
}