using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// UnitOfMeasureTypeDTO Domain Object
    /// </summary>
    public partial class UnitOfMeasureType
    {

        public string UOMType { get; set; }
        public string Description { get; set; }

    }

}

