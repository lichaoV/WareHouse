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
            v.GoodsName = "dLU";
            v.Producer = "Dpdjb";
            v.Specification = "6KEoTU";
            v.BatchNumber = "kffpyAMo";
            v.ApprovalNo = "vol";
            v.SellingPrice = 34;
            v.InputNumber = 9;
            v.WarningValue = 79;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInput>().FirstOrDefault();
				
                Assert.AreEqual(data.GoodsName, "dLU");
                Assert.AreEqual(data.Producer, "Dpdjb");
                Assert.AreEqual(data.Specification, "6KEoTU");
                Assert.AreEqual(data.BatchNumber, "kffpyAMo");
                Assert.AreEqual(data.ApprovalNo, "vol");
                Assert.AreEqual(data.SellingPrice, 34);
                Assert.AreEqual(data.InputNumber, 9);
                Assert.AreEqual(data.WarningValue, 79);
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
                v.GoodsName = "dLU";
                v.Producer = "Dpdjb";
                v.Specification = "6KEoTU";
                v.BatchNumber = "kffpyAMo";
                v.ApprovalNo = "vol";
                v.SellingPrice = 34;
                v.InputNumber = 9;
                v.WarningValue = 79;
                context.Set<GoodsInput>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(GoodsInputVM));

            GoodsInputVM vm = rv.Model as GoodsInputVM;
            v = new GoodsInput();
            v.ID = vm.Entity.ID;
       		
            v.GoodsName = "nD0jQ";
            v.Producer = "rZYuAZ";
            v.Specification = "tIWNh";
            v.BatchNumber = "D7C";
            v.ApprovalNo = "cAg";
            v.SellingPrice = 92;
            v.InputNumber = 61;
            v.WarningValue = 78;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SupplierId", "");
            vm.FC.Add("Entity.GoodsName", "");
            vm.FC.Add("Entity.Producer", "");
            vm.FC.Add("Entity.Specification", "");
            vm.FC.Add("Entity.BatchNumber", "");
            vm.FC.Add("Entity.ApprovalNo", "");
            vm.FC.Add("Entity.SellingPrice", "");
            vm.FC.Add("Entity.InputNumber", "");
            vm.FC.Add("Entity.WarningValue", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<GoodsInput>().FirstOrDefault();
 				
                Assert.AreEqual(data.GoodsName, "nD0jQ");
                Assert.AreEqual(data.Producer, "rZYuAZ");
                Assert.AreEqual(data.Specification, "tIWNh");
                Assert.AreEqual(data.BatchNumber, "D7C");
                Assert.AreEqual(data.ApprovalNo, "cAg");
                Assert.AreEqual(data.SellingPrice, 92);
                Assert.AreEqual(data.InputNumber, 61);
                Assert.AreEqual(data.WarningValue, 78);
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
                v.GoodsName = "dLU";
                v.Producer = "Dpdjb";
                v.Specification = "6KEoTU";
                v.BatchNumber = "kffpyAMo";
                v.ApprovalNo = "vol";
                v.SellingPrice = 34;
                v.InputNumber = 9;
                v.WarningValue = 79;
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
                v.GoodsName = "dLU";
                v.Producer = "Dpdjb";
                v.Specification = "6KEoTU";
                v.BatchNumber = "kffpyAMo";
                v.ApprovalNo = "vol";
                v.SellingPrice = 34;
                v.InputNumber = 9;
                v.WarningValue = 79;
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
                v1.GoodsName = "dLU";
                v1.Producer = "Dpdjb";
                v1.Specification = "6KEoTU";
                v1.BatchNumber = "kffpyAMo";
                v1.ApprovalNo = "vol";
                v1.SellingPrice = 34;
                v1.InputNumber = 9;
                v1.WarningValue = 79;
                v2.SupplierId = v1.SupplierId; 
                v2.GoodsName = "nD0jQ";
                v2.Producer = "rZYuAZ";
                v2.Specification = "tIWNh";
                v2.BatchNumber = "D7C";
                v2.ApprovalNo = "cAg";
                v2.SellingPrice = 92;
                v2.InputNumber = 61;
                v2.WarningValue = 78;
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

                v.SupplierName = "5y8LDOl";
                v.Contract = "A9GD3Xllp";
                v.ContractPhone = "ADP2G";
                context.Set<Supplier>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
