using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Output.SaleOutputVMs
{
    public partial class SaleOutputListVM : BasePagedListVM<SaleOutput_View, SaleOutputSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.Create, "新建","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.Edit, "修改","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.Delete, "删除", "Output",dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.Details, "详细","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.BatchEdit, "批量修改","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.BatchDelete, "批量删除","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.Import, "导入","Output", dialogWidth: 800),
                this.MakeStandardAction("SaleOutput", GridActionStandardTypesEnum.ExportExcel, "导出","Output"),
            };
        }

        protected override IEnumerable<IGridColumn<SaleOutput_View>> InitGridHeader()
        {
            return new List<GridColumn<SaleOutput_View>>{
                this.MakeGridHeader(x => x.SalesmanName_view),
                this.MakeGridHeader(x => x.SaleTime),
                this.MakeGridHeader(x => x.CustomerName_view),
                this.MakeGridHeader(x => x.GoodsName_view),
                this.MakeGridHeader(x => x.SaleNumber),
                this.MakeGridHeader(x => x.SalePrice),
                this.MakeGridHeader(x => x.PayType),
                this.MakeGridHeader(x => x.SaleRemark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SaleOutput_View> GetSearchQuery()
        {
            var query = DC.Set<SaleOutput>()
                .CheckEqual(Searcher.SalesmanId, x=>x.SalesmanId)
                .CheckEqual(Searcher.CustomerId, x=>x.CustomerId)
                .CheckEqual(Searcher.GoodsInfoId, x=>x.GoodsInfoId)
                .Select(x => new SaleOutput_View
                {
				    ID = x.ID,
                    SalesmanName_view = x.Salesman.SalesmanName,
                    SaleTime = x.SaleTime,
                    CustomerName_view = x.Customer.CustomerName,
                    GoodsName_view = x.GoodsInfo.GoodsName,
                    SaleNumber = x.SaleNumber,
                    SalePrice = x.SalePrice,
                    PayType = x.PayType,
                    SaleRemark = x.SaleRemark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SaleOutput_View : SaleOutput{
        [Display(Name = "销售员姓名")]
        public String SalesmanName_view { get; set; }
        [Display(Name = "客户名称")]
        public String CustomerName_view { get; set; }
        [Display(Name = "商品名称")]
        public String GoodsName_view { get; set; }

    }
}
