using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Basic.SupplierVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class SupplierControllerTest
    {
        private SupplierController _controller;
        private string _seed;

        public SupplierControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SupplierController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as SupplierListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SupplierVM));

            SupplierVM vm = rv.Model as SupplierVM;
            Supplier v = new Supplier();
			
            v.SupplierName = "RLDsNsylB";
            v.Contract = "eUN";
            v.ContractPhone = "z1DBC";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Supplier>().FirstOrDefault();
				
                Assert.AreEqual(data.SupplierName, "RLDsNsylB");
                Assert.AreEqual(data.Contract, "eUN");
                Assert.AreEqual(data.ContractPhone, "z1DBC");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Supplier v = new Supplier();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SupplierName = "RLDsNsylB";
                v.Contract = "eUN";
                v.ContractPhone = "z1DBC";
                context.Set<Supplier>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SupplierVM));

            SupplierVM vm = rv.Model as SupplierVM;
            v = new Supplier();
            v.ID = vm.Entity.ID;
       		
            v.SupplierName = "yJqCDMaM";
            v.Contract = "SNUjoc";
            v.ContractPhone = "aW1b";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SupplierName", "");
            vm.FC.Add("Entity.Contract", "");
            vm.FC.Add("Entity.ContractPhone", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Supplier>().FirstOrDefault();
 				
                Assert.AreEqual(data.SupplierName, "yJqCDMaM");
                Assert.AreEqual(data.Contract, "SNUjoc");
                Assert.AreEqual(data.ContractPhone, "aW1b");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Supplier v = new Supplier();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SupplierName = "RLDsNsylB";
                v.Contract = "eUN";
                v.ContractPhone = "z1DBC";
                context.Set<Supplier>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SupplierVM));

            SupplierVM vm = rv.Model as SupplierVM;
            v = new Supplier();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Supplier>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Supplier v = new Supplier();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.SupplierName = "RLDsNsylB";
                v.Contract = "eUN";
                v.ContractPhone = "z1DBC";
                context.Set<Supplier>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Supplier v1 = new Supplier();
            Supplier v2 = new Supplier();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SupplierName = "RLDsNsylB";
                v1.Contract = "eUN";
                v1.ContractPhone = "z1DBC";
                v2.SupplierName = "yJqCDMaM";
                v2.Contract = "SNUjoc";
                v2.ContractPhone = "aW1b";
                context.Set<Supplier>().Add(v1);
                context.Set<Supplier>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SupplierBatchVM));

            SupplierBatchVM vm = rv.Model as SupplierBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Supplier>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as SupplierListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
