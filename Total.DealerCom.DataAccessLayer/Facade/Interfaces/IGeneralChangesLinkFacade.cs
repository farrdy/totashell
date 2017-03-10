using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IGeneralChangesLinkFacade
    {
        GeneralChangesLink Create(GeneralChangesLink link);

        GeneralChangesLink Update(GeneralChangesLink link);
    }
}
