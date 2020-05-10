using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Basic.StoreHouseVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class StoreHouseControllerTest
    {
        private StoreHouseController _controller;
        private string _seed;

        public StoreHouseControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<StoreHouseController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as StoreHouseListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(StoreHouseVM));

            StoreHouseVM vm = rv.Model as StoreHouseVM;
            StoreHouse v = new StoreHouse();
			
            v.WarehouseCode = "Jm78";
            v.WarehouseAddress = "M9B";
            v.ContractName = "TxlQdb31";
            v.ContractPhone = "Vww3t";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StoreHouse>().FirstOrDefault();
				
                Assert.AreEqual(data.WarehouseCode, "Jm78");
                Assert.AreEqual(data.WarehouseAddress, "M9B");
                Assert.AreEqual(data.ContractName, "TxlQdb31");
                Assert.AreEqual(data.ContractPhone, "Vww3t");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.WarehouseCode = "Jm78";
                v.WarehouseAddress = "M9B";
                v.ContractName = "TxlQdb31";
                v.ContractPhone = "Vww3t";
                context.Set<StoreHouse>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StoreHouseVM));

            StoreHouseVM vm = rv.Model as StoreHouseVM;
            v = new StoreHouse();
            v.ID = vm.Entity.ID;
       		
            v.WarehouseCode = "NgIudeNx";
            v.WarehouseAddress = "INq1";
            v.ContractName = "zE7Ho";
            v.ContractPhone = "6dCP";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.WarehouseCode", "");
            vm.FC.Add("Entity.WarehouseAddress", "");
            vm.FC.Add("Entity.ContractName", "");
            vm.FC.Add("Entity.ContractPhone", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StoreHouse>().FirstOrDefault();
 				
                Assert.AreEqual(data.WarehouseCode, "NgIudeNx");
                Assert.AreEqual(data.WarehouseAddress, "INq1");
                Assert.AreEqual(data.ContractName, "zE7Ho");
                Assert.AreEqual(data.ContractPhone, "6dCP");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.WarehouseCode = "Jm78";
                v.WarehouseAddress = "M9B";
                v.ContractName = "TxlQdb31";
                v.ContractPhone = "Vww3t";
                context.Set<StoreHouse>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StoreHouseVM));

            StoreHouseVM vm = rv.Model as StoreHouseVM;
            v = new StoreHouse();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<StoreHouse>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.WarehouseCode = "Jm78";
                v.WarehouseAddress = "M9B";
                v.ContractName = "TxlQdb31";
                v.ContractPhone = "Vww3t";
                context.Set<StoreHouse>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StoreHouse v1 = new StoreHouse();
            StoreHouse v2 = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.WarehouseCode = "Jm78";
                v1.WarehouseAddress = "M9B";
                v1.ContractName = "TxlQdb31";
                v1.ContractPhone = "Vww3t";
                v2.WarehouseCode = "NgIudeNx";
                v2.WarehouseAddress = "INq1";
                v2.ContractName = "zE7Ho";
                v2.ContractPhone = "6dCP";
                context.Set<StoreHouse>().Add(v1);
                context.Set<StoreHouse>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(StoreHouseBatchVM));

            StoreHouseBatchVM vm = rv.Model as StoreHouseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<StoreHouse>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as StoreHouseListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
