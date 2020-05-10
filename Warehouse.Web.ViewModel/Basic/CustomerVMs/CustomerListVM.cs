using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.CustomerVMs
{
    public partial class CustomerListVM : BasePagedListVM<Customer_View, CustomerSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Create, "新建","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Edit, "修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Delete, "删除", "Basic",dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Details, "详细","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.BatchEdit, "批量修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.BatchDelete, "批量删除","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Import, "导入","Basic", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.ExportExcel, "导出","Basic"),
            };
        }

        protected override IEnumerable<IGridColumn<Customer_View>> InitGridHeader()
        {
            return new List<GridColumn<Customer_View>>{
                this.MakeGridHeader(x => x.CustomerName),
                this.MakeGridHeader(x => x.CustomerAddress),
                this.MakeGridHeader(x => x.CustomerPhone),
                this.MakeGridHeader(x => x.ZipCode),
                this.MakeGridHeader(x => x.Contract),
                this.MakeGridHeader(x => x.ContractPhone),
                this.MakeGridHeader(x => x.DepositBank),
                this.MakeGridHeader(x => x.BankAccount),
                this.MakeGridHeader(x => x.ActiveFlag),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Customer_View> GetSearchQuery()
        {
            var query = DC.Set<Customer>()
                .CheckContain(Searcher.CustomerName, x=>x.CustomerName)
                .CheckContain(Searcher.Contract, x=>x.Contract)
                .CheckContain(Searcher.ContractPhone, x=>x.ContractPhone)
                .Select(x => new Customer_View
                {
				    ID = x.ID,
                    CustomerName = x.CustomerName,
                    CustomerAddress = x.CustomerAddress,
                    CustomerPhone = x.CustomerPhone,
                    ZipCode = x.ZipCode,
                    Contract = x.Contract,
                    ContractPhone = x.ContractPhone,
                    DepositBank = x.DepositBank,
                    BankAccount = x.BankAccount,
                    ActiveFlag = x.ActiveFlag,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Customer_View : Customer{

    }
}
