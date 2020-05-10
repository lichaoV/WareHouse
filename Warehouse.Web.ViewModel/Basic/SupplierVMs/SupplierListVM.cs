using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.SupplierVMs
{
    public partial class SupplierListVM : BasePagedListVM<Supplier_View, SupplierSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.Create, "新建","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.Edit, "修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.Delete, "删除", "Basic",dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.Details, "详细","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.BatchEdit, "批量修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.BatchDelete, "批量删除","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.Import, "导入","Basic", dialogWidth: 800),
                this.MakeStandardAction("Supplier", GridActionStandardTypesEnum.ExportExcel, "导出","Basic"),
            };
        }

        protected override IEnumerable<IGridColumn<Supplier_View>> InitGridHeader()
        {
            return new List<GridColumn<Supplier_View>>{
                this.MakeGridHeader(x => x.SupplierName),
                this.MakeGridHeader(x => x.SupplierAddress),
                this.MakeGridHeader(x => x.SupplierPhone),
                this.MakeGridHeader(x => x.ZipCode),
                this.MakeGridHeader(x => x.Contract),
                this.MakeGridHeader(x => x.ContractPhone),
                this.MakeGridHeader(x => x.DepositBank),
                this.MakeGridHeader(x => x.BankAccount),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Supplier_View> GetSearchQuery()
        {
            var query = DC.Set<Supplier>()
                .CheckContain(Searcher.SupplierName, x=>x.SupplierName)
                .CheckContain(Searcher.SupplierPhone, x=>x.SupplierPhone)
                .CheckContain(Searcher.Contract, x=>x.Contract)
                .CheckContain(Searcher.ContractPhone, x=>x.ContractPhone)
                .Select(x => new Supplier_View
                {
				    ID = x.ID,
                    SupplierName = x.SupplierName,
                    SupplierAddress = x.SupplierAddress,
                    SupplierPhone = x.SupplierPhone,
                    ZipCode = x.ZipCode,
                    Contract = x.Contract,
                    ContractPhone = x.ContractPhone,
                    DepositBank = x.DepositBank,
                    BankAccount = x.BankAccount,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Supplier_View : Supplier{

    }
}
