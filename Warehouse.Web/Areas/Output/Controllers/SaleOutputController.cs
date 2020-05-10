using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.ViewModel.Output.SaleOutputVMs;

namespace Warehouse.Web.Controllers
{
    [Area("Output")]
    [ActionDescription("销售管理")]
    public partial class SaleOutputController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<SaleOutputListVM>();
            return PartialView(vm);
        }

        [ActionDescription("搜索")]
        [HttpPost]
        public string Search(SaleOutputListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region 新建
        [ActionDescription("新建")]
        public ActionResult Create()
        {
            var vm = CreateVM<SaleOutputVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("新建")]
        public ActionResult Create(SaleOutputVM vm)
        {
            string sql = "SELECT * FROM GoodsInfos WHERE ID='{0}'";
            sql = string.Format(sql, vm.Entity.GoodsInfoId);
            DataTable dt = DC.RunSQL(sql);
            decimal oldNumber = new decimal();
            if (dt.Rows.Count > 0)
            {
                oldNumber = Convert.ToDecimal(dt.Rows[0]["InputNumber"].ToString());
            }

            decimal newNumber = oldNumber - vm.Entity.SaleNumber;

            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                sql = "UPDATE GoodsInfos SET InputNumber='{0}' WHERE ID='{1}'";
                sql = string.Format(sql, newNumber, vm.Entity.GoodsInfoId);
                var cmd = DC.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteReader();
                cmd.Connection.Close();

                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region 修改
        [ActionDescription("修改")]
        public ActionResult Edit(string id)
        {
            var vm = CreateVM<SaleOutputVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(SaleOutputVM vm)
        {
            string sql = "SELECT * FROM GoodsInfos WHERE ID='{0}'";
            sql = string.Format(sql, vm.Entity.GoodsInfoId);
            DataTable dt = DC.RunSQL(sql);
            decimal oldNumber = new decimal();
            if (dt.Rows.Count > 0)
            {
                oldNumber = Convert.ToDecimal(dt.Rows[0]["InputNumber"].ToString());
            }

            sql = "SELECT * FROM SaleOutputs WHERE ID='{0}'";
            sql = string.Format(sql, vm.Entity.ID);
            DataTable dt1 = DC.RunSQL(sql);
            decimal oldInputNumber = new decimal();
            decimal newInputNumber = vm.Entity.SaleNumber;
            if (dt1.Rows.Count > 0)
            {
                oldInputNumber = Convert.ToDecimal(dt1.Rows[0]["SaleNumber"].ToString());
            }

            decimal newNumber = decimal.MinValue;
            if (newInputNumber > oldInputNumber)
            {
                newNumber = oldNumber - (newInputNumber - oldInputNumber);
            }
            else if (newInputNumber < oldInputNumber)
            {
                newNumber = oldNumber + (oldInputNumber - newInputNumber);
            }

            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                sql = "UPDATE GoodsInfos SET InputNumber='{0}' WHERE ID='{1}'";
                sql = string.Format(sql, newNumber, vm.Entity.GoodsInfoId);
                var cmd = DC.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteReader();
                cmd.Connection.Close();

                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion

        #region 退货
        [ActionDescription("退货")]
        public ActionResult Delete(string id)
        {
            var vm = CreateVM<SaleOutputVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("退货")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<SaleOutputVM>(id);

            string sql = "SELECT * FROM GoodsInfos WHERE ID='{0}'";
            sql = string.Format(sql, vm.Entity.GoodsInfoId);
            DataTable dt = DC.RunSQL(sql);
            decimal oldNumber = new decimal();
            if (dt.Rows.Count > 0)
            {
                oldNumber = Convert.ToDecimal(dt.Rows[0]["InputNumber"].ToString());
            }

            decimal newNumber = oldNumber + vm.Entity.SaleNumber;

            vm.DoRealDelete();

            sql = "UPDATE GoodsInfos SET InputNumber='{0}' WHERE ID='{1}'";
            sql = string.Format(sql, newNumber, vm.Entity.GoodsInfoId);
            var cmd = DC.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteReader();
            cmd.Connection.Close();

            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region 详细
        [ActionDescription("详细")]
        public ActionResult Details(string id)
        {
            var vm = CreateVM<SaleOutputVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region 批量修改
        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<SaleOutputBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult DoBatchEdit(SaleOutputBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView("BatchEdit", vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有" + vm.Ids.Length + "条数据被修改");
            }
        }
        #endregion

        #region 批量删除
        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult BatchDelete(string[] IDs)
        {
            var vm = CreateVM<SaleOutputBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult DoBatchDelete(SaleOutputBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete", vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有" + vm.Ids.Length + "条数据被删除");
            }
        }
        #endregion

        #region 导入
        [ActionDescription("导入")]
        public ActionResult Import()
        {
            var vm = CreateVM<SaleOutputImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("导入")]
        public ActionResult Import(SaleOutputImportVM vm, IFormCollection nouse)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("成功导入 " + vm.EntityList.Count.ToString() + " 行数据");
            }
        }
        #endregion

        [ActionDescription("导出")]
        [HttpPost]
        public IActionResult ExportExcel(SaleOutputListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_SaleOutput_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

    }
}
