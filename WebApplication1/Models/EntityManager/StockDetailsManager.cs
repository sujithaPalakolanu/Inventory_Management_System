using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;
using WebApplication1.Services;

namespace WebApplication1.Models.EntityManager
{
    public class StockDetailsManager
    {
        public InventoryDBEntities2 _Context;

        public StockDetailsManager(InventoryDBEntities2 context)
        {
            _Context = context;
            CustomSchedular.IntervalInDays(00, 00, 1,
               () =>
               {
                   updateStockDetails();
               });
        }

        /// <summary>
        /// Gets existing stock details from DB
        /// </summary>
        /// <returns></returns>
        public List<StockDetail> getStockDetails()
        {
            var list = _Context.StockDetails.ToList();
            return list;
        }

        /// <summary>
        /// Gets Categories from DB
        /// </summary>
        /// <returns></returns>
        public List<category> getCaregories()
        {

            using (InventoryDBEntities2 db = new InventoryDBEntities2())
            {
                return db.categories.ToList();
            }
        }

        /// <summary>
        /// gets sell in updated list
        /// </summary>
        /// <returns></returns>
        public List<StockDetail> GetUpdatedSellinList()
        {
            List<StockDetail> updatedList = new List<StockDetail>();
            List<StockDetail> stockdetails = getStockDetails();

            if (stockdetails != null)
            {
                foreach (var list in stockdetails)
                {
                    if (list.categoryID != 3)
                        list.sellinValue = list.sellinValue - 1;
                    updatedList.Add(list);
                }
            }
            return updatedList;
        }

        /// <summary>
        /// Gets Final updated Stock Details
        /// </summary>
        /// <returns></returns>
        public List<StockDetail> GetUpdatedStockDetails()
        {
            List<StockDetail> finalStockList = new List<StockDetail>();
            List<StockDetail> stockdetails = new List<StockDetail>();

            stockdetails = GetUpdatedSellinList();

            //Get list based on quality flag
            var qualityIncreseList = stockdetails.Where(x => x.category.qualityFlag == 1).ToList();
            var qualityDecreaseList = stockdetails.Where(x => x.category.qualityFlag == -1).ToList();
            var nutralQualityList = stockdetails.Where(x => x.category.qualityFlag == 0).ToList();

            finalStockList.AddRange(nutralQualityList);

            //Logic for quality increase list based on business rules
            if (qualityIncreseList != null)
            {
                DateTime dateTime = DateTime.Now;
                if (dateTime.Day == new DateTime(2020, 12, 25).Day
                    && dateTime.Month == new DateTime(2020, 12, 25).Month)
                {
                    foreach (var list in qualityIncreseList)
                    {
                        list.quality = 0;
                    }
                }
                else
                {
                    foreach (var list in qualityIncreseList)
                    {
                        if (list.sellinValue >= 0)
                        {
                            if (list.sellinValue <= 10)
                            {
                                if (list.sellinValue < 5)
                                    list.quality = list.quality + 3;
                                else
                                    list.quality = list.quality + 2; ;
                            }

                            else
                                list.quality = list.quality + 1;
                        }
                        else
                            list.quality = list.quality - 2;

                        finalStockList.Add(list);
                    }
                }
            }
            if (qualityDecreaseList != null)
            {
                foreach (var list in qualityDecreaseList)
                {
                    int frozenDecreaseValue = 1;
                    int freshItemDecreaseValue = 2;
                    if (list.sellinValue < 0)
                    {
                        freshItemDecreaseValue = 2;
                        freshItemDecreaseValue = 4;
                    }
                    if (list.categoryID == 4)
                        list.quality = list.quality - frozenDecreaseValue;
                    if (list.categoryID == 5)
                        list.quality = list.quality - freshItemDecreaseValue;
                    finalStockList.Add(list);
                }
            }
            finalStockList = GetListWithQualityBoundryCheck(finalStockList);

            return finalStockList;

        }

        /// <summary>
        /// Validates quality parameter higher and lower boundaries and gets final list.
        /// </summary>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public List<StockDetail> GetListWithQualityBoundryCheck(List<StockDetail> stockList)
        {
            if (stockList != null)
            {
                foreach (var list in stockList)
                {
                    if (list.quality > 50)
                        list.quality = 50;
                    if (list.quality < 0)
                        list.quality = 0;
                }
            }
            return stockList;
        }

        /// <summary>
        /// Update StockDetails in DB
        /// </summary>
        public void updateStockDetails()
        {
            var UTD = new UserDefinedType();

            using (var DB = new InventoryDBEntities2())
            {
                DataTable _DataTable = UTD.GenerateDataTable();

                SqlParameter Parameter = new SqlParameter("@StockInput", _DataTable);
                Parameter.TypeName = "dbo.tblStockDetails";

                DB.Database.ExecuteSqlCommand("exec usp_UpdateStockDetails @StockInput", Parameter);


            }

            //DbContext contextDB = new DbContext("ConnectionString");

            //var procedure = new USPUpdateStockDetails()
            //{
            //    userDefinedType = utdList

            //};
            //contextDB.Database.ExecuteStoredProcedure(procedure);
        }

        
    }
}
