using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Basic.GoodsInfoVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class GoodsInfoControllerTest
    {
        private GoodsInfoController _controller;
        private string _seed;

        public GoodsInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<GoodsInfoController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as GoodsInfoListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInfoVM));

            GoodsInfoVM vm = rv.Model as GoodsInfoVM;
            GoodsInfo v = new GoodsInfo();
			
            v.GoodsName = "vhL";
            v.Specification = "YcSpzRax";
            v.SellingPrice = 37;
            v.InputNumber = 67;
            v.WarningValue = 25;
            v.StoreHouseId = AddStoreHouse();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInfo>().FirstOrDefault();
				
                Assert.AreEqual(data.GoodsName, "vhL");
                Assert.AreEqual(data.Specification, "YcSpzRax");
                Assert.AreEqual(data.SellingPrice, 37);
                Assert.AreEqual(data.InputNumber, 67);
                Assert.AreEqual(data.WarningValue, 25);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            GoodsInfo v = new GoodsInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.GoodsName = "vhL";
                v.Specification = "YcSpzRax";
                v.SellingPrice = 37;
                v.InputNumber = 67;
                v.WarningValue = 25;
                v.StoreHouseId = AddStoreHouse();
                context.Set<GoodsInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInfoVM));

            GoodsInfoVM vm = rv.Model as GoodsInfoVM;
            v = new GoodsInfo();
            v.ID = vm.Entity.ID;
       		
            v.GoodsName = "BDnG";
            v.Specification = "Dtz";
            v.SellingPrice = 14;
            v.InputNumber = 54;
            v.WarningValue = 86;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.GoodsName", "");
            vm.FC.Add("Entity.Specification", "");
            vm.FC.Add("Entity.SellingPrice", "");
            vm.FC.Add("Entity.InputNumber", "");
            vm.FC.Add("Entity.WarningValue", "");
            vm.FC.Add("Entity.StoreHouseId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.GoodsName, "BDnG");
                Assert.AreEqual(data.Specification, "Dtz");
                Assert.AreEqual(data.SellingPrice, 14);
                Assert.AreEqual(data.InputNumber, 54);
                Assert.AreEqual(data.WarningValue, 86);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            GoodsInfo v = new GoodsInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.GoodsName = "vhL";
                v.Specification = "YcSpzRax";
                v.SellingPrice = 37;
                v.InputNumber = 67;
                v.WarningValue = 25;
                v.StoreHouseId = AddStoreHouse();
                context.Set<GoodsInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInfoVM));

            GoodsInfoVM vm = rv.Model as GoodsInfoVM;
            v = new GoodsInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GoodsInfo>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            GoodsInfo v = new GoodsInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.GoodsName = "vhL";
                v.Specification = "YcSpzRax";
                v.SellingPrice = 37;
                v.InputNumber = 67;
                v.WarningValue = 25;
                v.StoreHouseId = AddStoreHouse();
                context.Set<GoodsInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            GoodsInfo v1 = new GoodsInfo();
            GoodsInfo v2 = new GoodsInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.GoodsName = "vhL";
                v1.Specification = "YcSpzRax";
                v1.SellingPrice = 37;
                v1.InputNumber = 67;
                v1.WarningValue = 25;
                v1.StoreHouseId = AddStoreHouse();
                v2.GoodsName = "BDnG";
                v2.Specification = "Dtz";
                v2.SellingPrice = 14;
                v2.InputNumber = 54;
                v2.WarningValue = 86;
                v2.StoreHouseId = v1.StoreHouseId; 
                context.Set<GoodsInfo>().Add(v1);
                context.Set<GoodsInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInfoBatchVM));

            GoodsInfoBatchVM vm = rv.Model as GoodsInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GoodsInfo>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as GoodsInfoListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddStoreHouse()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.WarehouseCode = "iZUW";
                v.WarehouseAddress = "TmxY";
                v.ContractName = "5RMRFbb";
                v.ContractPhone = "UQeQFutWe";
                context.Set<StoreHouse>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
