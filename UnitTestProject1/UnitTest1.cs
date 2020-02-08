using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.DB;
using WebApplication1.Models.EntityManager;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getStockDetails_AgerBrie_Test()
        {

            var data = new List<StockDetail>
            { 
                new StockDetail { categoryID = 1, sellinValue = 1, quality = 1, category = new category{ qualityFlag = 1} },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 1, sellinValue = 0, quality = 2},
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);


        }

         [TestMethod]
        public void getStockDetails_cristmasCrackers_case1_Test()
        {

            var data = new List<StockDetail>
            {
                new StockDetail { categoryID = 2, sellinValue = -1, quality = 2, category = new category{ qualityFlag = 1} },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 2, sellinValue = -2, quality = 0 },
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }

        [TestMethod]
        public void getStockDetails_cristmasCrackers_case2_Test()
        {

            var data = new List<StockDetail>
            {
                new StockDetail { categoryID = 2, sellinValue = 9, quality = 2, category = new category{ qualityFlag = 1} },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 2, sellinValue = 8, quality = 4 },
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }


        [TestMethod]
        public void getStockDetails_Soap_Test()
        {

            var data = new List<StockDetail>
            {
                new StockDetail { categoryID = 3, sellinValue = 2, quality = 2, category = new category{ qualityFlag = 0}},
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 3, sellinValue = 2, quality = 2},
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }

        [TestMethod]
        public void getStockDetails_FrozenItem_case1_Test()
        {

            var data = new List<StockDetail>
            {
                new StockDetail { categoryID = 4, sellinValue = -1, quality = 55, category = new category{ qualityFlag = -1} },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 4, sellinValue = -2, quality = 50 },
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }

        [TestMethod]
        public void getStockDetails_FrozenItem_case2_Test()
        {

            var data = new List<StockDetail>
            {
                 new StockDetail { categoryID = 4, sellinValue = 2, quality = 2, category = new category{ qualityFlag = -1}  },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                 new StockDetail { categoryID = 4, sellinValue = 1, quality = 1 },
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }

        [TestMethod]
        public void getStockDetails_freshIteam_case1_Test()
        {

            var data = new List<StockDetail>
            {
                new StockDetail { categoryID = 5, sellinValue = 2, quality = 2, category = new category{ qualityFlag = -1}  },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
                new StockDetail { categoryID = 5, sellinValue = 1, quality = 0},
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }

        [TestMethod]
        public void getStockDetails_freshIteam_case2_Test()
        {

            var data = new List<StockDetail>
            {
               new StockDetail { categoryID = 5, sellinValue = - 1, quality = 5, category = new category{ qualityFlag = -1}  },
            }.AsQueryable();

            var outPut = new List<StockDetail>
            {
               
               new StockDetail { categoryID = 5, sellinValue = - 2, quality = 1},
            };

            var mockSet = new Mock<System.Data.Entity.DbSet<StockDetail>>();
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StockDetail>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<InventoryDBEntities2>();
            mockContext.Setup(m => m.StockDetails).Returns(mockSet.Object);

            Mock<StockDetailsManager> stockDetailsManager = new Mock<StockDetailsManager>(mockContext.Object);


            var service_result = stockDetailsManager.Object.GetUpdatedStockDetails();

            Assert.AreEqual(outPut.FirstOrDefault().categoryID, service_result.FirstOrDefault().categoryID);
            Assert.AreEqual(outPut.FirstOrDefault().sellinValue, service_result.FirstOrDefault().sellinValue);
            Assert.AreEqual(outPut.FirstOrDefault().quality, service_result.FirstOrDefault().quality);
        }
    }
}
