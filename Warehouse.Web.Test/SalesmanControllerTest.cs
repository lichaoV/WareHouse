using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Basic.SalesmanVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class SalesmanControllerTest
    {
        private SalesmanController _controller;
        private string _seed;

        public SalesmanControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SalesmanController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as SalesmanListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SalesmanVM));

            SalesmanVM vm = rv.Model as SalesmanVM;
            Salesman v = new Salesman();
			
            v.SalesmanName = "qFFe";
            v.SalesmanCode = "xGWs1M";
            v.SalesmanPhone = "1tINh";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Salesman>().FirstOrDefault();
				
                Assert.AreEqual(data.SalesmanName, "qFFe");
                Assert.AreEqual(data.SalesmanCode, "xGWs1M");
                Assert.AreEqual(data.SalesmanPhone, "1tINh");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Salesman v = new Salesman();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SalesmanName = "qFFe";
                v.SalesmanCode = "xGWs1M";
                v.SalesmanPhone = "1tINh";
                context.Set<Salesman>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SalesmanVM));

            SalesmanVM vm = rv.Model as SalesmanVM;
            v = new Salesman();
            v.ID = vm.Entity.ID;
       		
            v.SalesmanName = "U6pu";
            v.SalesmanCode = "3qYHD0l";
            v.SalesmanPhone = "B8QQmR";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SalesmanName", "");
            vm.FC.Add("Entity.SalesmanCode", "");
            vm.FC.Add("Entity.SalesmanPhone", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Salesman>().FirstOrDefault();
 				
                Assert.AreEqual(data.SalesmanName, "U6pu");
                Assert.AreEqual(data.SalesmanCode, "3qYHD0l");
                Assert.AreEqual(data.SalesmanPhone, "B8QQmR");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Salesman v = new Salesman();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SalesmanName = "qFFe";
                v.SalesmanCode = "xGWs1M";
                v.SalesmanPhone = "1tINh";
                context.Set<Salesman>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SalesmanVM));

            SalesmanVM vm = rv.Model as SalesmanVM;
            v = new Salesman();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Salesman>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Salesman v = new Salesman();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.SalesmanName = "qFFe";
                v.SalesmanCode = "xGWs1M";
                v.SalesmanPhone = "1tINh";
                context.Set<Salesman>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Salesman v1 = new Salesman();
            Salesman v2 = new Salesman();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SalesmanName = "qFFe";
                v1.SalesmanCode = "xGWs1M";
                v1.SalesmanPhone = "1tINh";
                v2.SalesmanName = "U6pu";
                v2.SalesmanCode = "3qYHD0l";
                v2.SalesmanPhone = "B8QQmR";
                context.Set<Salesman>().Add(v1);
                context.Set<Salesman>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SalesmanBatchVM));

            SalesmanBatchVM vm = rv.Model as SalesmanBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Salesman>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as SalesmanListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
