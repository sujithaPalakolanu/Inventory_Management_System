using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models.EntityManager;

namespace WebApplication1.Models.DB
{
    [UserDefinedTableType("tblStockDetails")]
    public class UserDefinedType
    {
        [UserDefinedTableTypeColumn(1)]
        public int ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int sellinValue { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int quality { get; set; }

        public DataTable GenerateDataTable()
        {
            InventoryDBEntities2 Context = new InventoryDBEntities2();
            StockDetailsManager SDM = new StockDetailsManager(Context);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("sellinValue");
            dt.Columns.Add("quality");

            var finalList = SDM.GetUpdatedStockDetails();
            foreach (var list in finalList)
            {
                DataRow row = dt.NewRow();
                row["ID"] = list.ID;
                row["sellinValue"] = list.sellinValue;
                row["quality"] = list.quality;

                dt.Rows.Add(row);

            }          

            return dt;
        }
    }


}