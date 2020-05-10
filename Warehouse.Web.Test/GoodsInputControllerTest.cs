using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Input.GoodsInputVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class GoodsInputControllerTest
    {
        private GoodsInputController _controller;
        private string _seed;

        public GoodsInputControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<GoodsInputController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as GoodsInputListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInputVM));

            GoodsInputVM vm = rv.Model as GoodsInputVM;
            GoodsInput v = new GoodsInput();
			
            v.SupplierId = AddSupplier();
            v.GoodsInfoId = AddGoodsInfo();
            v.InputNumber = 87;
            v.Producer = "GAkoZLR";
            v.BatchNumber = "A2w6DoAs";
            v.ApprovalNo = "Z4cm";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInput>().FirstOrDefault();
				
                Assert.AreEqual(data.InputNumber, 87);
                Assert.AreEqual(data.Producer, "GAkoZLR");
                Assert.AreEqual(data.BatchNumber, "A2w6DoAs");
                Assert.AreEqual(data.ApprovalNo, "Z4cm");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            GoodsInput v = new GoodsInput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SupplierId = AddSupplier();
                v.GoodsInfoId = AddGoodsInfo();
                v.InputNumber = 87;
                v.Producer = "GAkoZLR";
                v.BatchNumber = "A2w6DoAs";
                v.ApprovalNo = "Z4cm";
                context.Set<GoodsInput>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInputVM));

            GoodsInputVM vm = rv.Model as GoodsInputVM;
            v = new GoodsInput();
            v.ID = vm.Entity.ID;
       		
            v.InputNumber = 19;
            v.Producer = "rzWULy";
            v.BatchNumber = "IQK0Yeopa";
            v.ApprovalNo = "Usha";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SupplierId", "");
            vm.FC.Add("Entity.GoodsInfoId", "");
            vm.FC.Add("Entity.InputNumber", "");
            vm.FC.Add("Entity.Producer", "");
            vm.FC.Add("Entity.BatchNumber", "");
            vm.FC.Add("Entity.ApprovalNo", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInput>().FirstOrDefault();
 				
                Assert.AreEqual(data.InputNumber, 19);
                Assert.AreEqual(data.Producer, "rzWULy");
                Assert.AreEqual(data.BatchNumber, "IQK0Yeopa");
                Assert.AreEqual(data.ApprovalNo, "Usha");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            GoodsInput v = new GoodsInput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SupplierId = AddSupplier();
                v.GoodsInfoId = AddGoodsInfo();
                v.InputNumber = 87;
                v.Producer = "GAkoZLR";
                v.BatchNumber = "A2w6DoAs";
                v.ApprovalNo = "Z4cm";
                context.Set<GoodsInput>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInputVM));

            GoodsInputVM vm = rv.Model as GoodsInputVM;
            v = new GoodsInput();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GoodsInput>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            GoodsInput v = new GoodsInput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.SupplierId = AddSupplier();
                v.GoodsInfoId = AddGoodsInfo();
                v.InputNumber = 87;
                v.Producer = "GAkoZLR";
                v.BatchNumber = "A2w6DoAs";
                v.ApprovalNo = "Z4cm";
                context.Set<GoodsInput>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            GoodsInput v1 = new GoodsInput();
            GoodsInput v2 = new GoodsInput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SupplierId = AddSupplier();
                v1.GoodsInfoId = AddGoodsInfo();
                v1.InputNumber = 87;
                v1.Producer = "GAkoZLR";
                v1.BatchNumber = "A2w6DoAs";
                v1.ApprovalNo = "Z4cm";
                v2.SupplierId = v1.SupplierId; 
                v2.GoodsInfoId = v1.GoodsInfoId; 
                v2.InputNumber = 19;
                v2.Producer = "rzWULy";
                v2.BatchNumber = "IQK0Yeopa";
                v2.ApprovalNo = "Usha";
                context.Set<GoodsInput>().Add(v1);
                context.Set<GoodsInput>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInputBatchVM));

            GoodsInputBatchVM vm = rv.Model as GoodsInputBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<GoodsInput>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as GoodsInputListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSupplier()
        {
            Supplier v = new Supplier();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.SupplierName = "3Vt";
                v.Contract = "OUQ51b47G";
                v.ContractPhone = "pYRAyN";
                context.Set<Supplier>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddStoreHouse()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.WarehouseCode = "eumrkUhk";
                v.WarehouseAddress = "1lcQ";
                v.ContractName = "paWDf6YK";
                v.ContractPhone = "2CFrNFzy";
                context.Set<StoreHouse>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddGoodsInfo()
        {
            GoodsInfo v = new GoodsInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.GoodsName = "PWFs";
                v.Specification = "Tq9KUjH";
                v.SellingPrice = 87;
                v.InputNumber = 72;
                v.WarningValue = 14;
                v.StoreHouseId = AddStoreHouse();
                context.Set<GoodsInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
