using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.DTO
{
    /// <summary>
    /// UnitOfMeasureDTO Domain Object
    /// </summary>
    public partial class UnitOfMeasure
    {

        public string UOM { get; set; }
        public string Description { get; set; }

    }

}

