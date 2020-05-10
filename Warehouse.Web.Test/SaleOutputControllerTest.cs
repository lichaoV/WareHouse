using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Output.SaleOutputVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class SaleOutputControllerTest
    {
        private SaleOutputController _controller;
        private string _seed;

        public SaleOutputControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SaleOutputController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as SaleOutputListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SaleOutputVM));

            SaleOutputVM vm = rv.Model as SaleOutputVM;
            SaleOutput v = new SaleOutput();
			
            v.CustomerId = AddCustomer();
            v.GoodsInfoId = AddGoodsInfo();
            v.SaleNumber = 25;
            v.SalePrice = 19;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleOutput>().FirstOrDefault();
				
                Assert.AreEqual(data.SaleNumber, 25);
                Assert.AreEqual(data.SalePrice, 19);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SaleOutput v = new SaleOutput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.CustomerId = AddCustomer();
                v.GoodsInfoId = AddGoodsInfo();
                v.SaleNumber = 25;
                v.SalePrice = 19;
                context.Set<SaleOutput>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SaleOutputVM));

            SaleOutputVM vm = rv.Model as SaleOutputVM;
            v = new SaleOutput();
            v.ID = vm.Entity.ID;
       		
            v.SaleNumber = 51;
            v.SalePrice = 79;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.CustomerId", "");
            vm.FC.Add("Entity.GoodsInfoId", "");
            vm.FC.Add("Entity.SaleNumber", "");
            vm.FC.Add("Entity.SalePrice", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SaleOutput>().FirstOrDefault();
 				
                Assert.AreEqual(data.SaleNumber, 51);
                Assert.AreEqual(data.SalePrice, 79);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SaleOutput v = new SaleOutput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.CustomerId = AddCustomer();
                v.GoodsInfoId = AddGoodsInfo();
                v.SaleNumber = 25;
                v.SalePrice = 19;
                context.Set<SaleOutput>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SaleOutputVM));

            SaleOutputVM vm = rv.Model as SaleOutputVM;
            v = new SaleOutput();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SaleOutput>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SaleOutput v = new SaleOutput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.CustomerId = AddCustomer();
                v.GoodsInfoId = AddGoodsInfo();
                v.SaleNumber = 25;
                v.SalePrice = 19;
                context.Set<SaleOutput>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SaleOutput v1 = new SaleOutput();
            SaleOutput v2 = new SaleOutput();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CustomerId = AddCustomer();
                v1.GoodsInfoId = AddGoodsInfo();
                v1.SaleNumber = 25;
                v1.SalePrice = 19;
                v2.CustomerId = v1.CustomerId; 
                v2.GoodsInfoId = v1.GoodsInfoId; 
                v2.SaleNumber = 51;
                v2.SalePrice = 79;
                context.Set<SaleOutput>().Add(v1);
                context.Set<SaleOutput>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SaleOutputBatchVM));

            SaleOutputBatchVM vm = rv.Model as SaleOutputBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SaleOutput>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as SaleOutputListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddCustomer()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.CustomerName = "Gwrst";
                v.Contract = "aalh74";
                v.ContractPhone = "Jzg7X";
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddStoreHouse()
        {
            StoreHouse v = new StoreHouse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.WarehouseCode = "OUrZ1YPS";
                v.WarehouseAddress = "pX8nakz";
                v.ContractName = "lnxG7n9p";
                v.ContractPhone = "37qxovgA";
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

                v.GoodsName = "q7By0";
                v.Specification = "f7IAdl8";
                v.SellingPrice = 98;
                v.InputNumber = 72;
                v.WarningValue = 6;
                v.StoreHouseId = AddStoreHouse();
                context.Set<GoodsInfo>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
