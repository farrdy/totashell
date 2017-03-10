using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IGeneralChangesLinkFacade
    {
        GeneralChangesLink Create(GeneralChangesLink link);

        GeneralChangesLink Update(GeneralChangesLink link);
    }
}
