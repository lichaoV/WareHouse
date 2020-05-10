using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Warehouse.Web.Controllers;
using Warehouse.Web.ViewModel.Basic.CustomerVMs;
using Warehouse.Web.Model;
using Warehouse.Web.DataAccess;

namespace Warehouse.Web.Test
{
    [TestClass]
    public class CustomerControllerTest
    {
        private CustomerController _controller;
        private string _seed;

        public CustomerControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<CustomerController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as CustomerListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            Customer v = new Customer();
			
            v.CustomerName = "kqblfz";
            v.Contract = "3NjMeNOb0";
            v.ContractPhone = "JsnbWwyR";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customer>().FirstOrDefault();
				
                Assert.AreEqual(data.CustomerName, "kqblfz");
                Assert.AreEqual(data.Contract, "3NjMeNOb0");
                Assert.AreEqual(data.ContractPhone, "JsnbWwyR");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.CustomerName = "kqblfz";
                v.Contract = "3NjMeNOb0";
                v.ContractPhone = "JsnbWwyR";
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            v = new Customer();
            v.ID = vm.Entity.ID;
       		
            v.CustomerName = "B0YSO";
            v.Contract = "Zwgfj45l";
            v.ContractPhone = "v2jYAFjJ";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.CustomerName", "");
            vm.FC.Add("Entity.Contract", "");
            vm.FC.Add("Entity.ContractPhone", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customer>().FirstOrDefault();
 				
                Assert.AreEqual(data.CustomerName, "B0YSO");
                Assert.AreEqual(data.Contract, "Zwgfj45l");
                Assert.AreEqual(data.ContractPhone, "v2jYAFjJ");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.CustomerName = "kqblfz";
                v.Contract = "3NjMeNOb0";
                v.ContractPhone = "JsnbWwyR";
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            v = new Customer();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Customer>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.CustomerName = "kqblfz";
                v.Contract = "3NjMeNOb0";
                v.ContractPhone = "JsnbWwyR";
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Customer v1 = new Customer();
            Customer v2 = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CustomerName = "kqblfz";
                v1.Contract = "3NjMeNOb0";
                v1.ContractPhone = "JsnbWwyR";
                v2.CustomerName = "B0YSO";
                v2.Contract = "Zwgfj45l";
                v2.ContractPhone = "v2jYAFjJ";
                context.Set<Customer>().Add(v1);
                context.Set<Customer>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerBatchVM));

            CustomerBatchVM vm = rv.Model as CustomerBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Customer>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as CustomerListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
