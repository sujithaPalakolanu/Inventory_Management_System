using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DB
{
    [StoredProcedure("usp_UpdateStockDetails")]
    public class USPUpdateStockDetails
    {
        [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "StockInput")]
        public List<UserDefinedType> userDefinedType { get; set; }
    }
}