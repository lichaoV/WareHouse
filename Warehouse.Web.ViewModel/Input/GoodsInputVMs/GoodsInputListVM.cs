using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Input.GoodsInputVMs
{
    public partial class GoodsInputListVM : BasePagedListVM<GoodsInput_View, GoodsInputSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.Create, "新建","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.Edit, "修改","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.Delete, "删除", "Input",dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.Details, "详细","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.BatchEdit, "批量修改","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.BatchDelete, "批量删除","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.Import, "导入","Input", dialogWidth: 800),
                this.MakeStandardAction("GoodsInput", GridActionStandardTypesEnum.ExportExcel, "导出","Input"),
            };
        }

        protected override IEnumerable<IGridColumn<GoodsInput_View>> InitGridHeader()
        {
            return new List<GridColumn<GoodsInput_View>>{
                this.MakeGridHeader(x => x.InputTime),
                this.MakeGridHeader(x => x.SupplierName_view),
                this.MakeGridHeader(x => x.GoodsName_view),
                this.MakeGridHeader(x => x.Producer),
                this.MakeGridHeader(x => x.BatchNumber),
                this.MakeGridHeader(x => x.ApprovalNo),
                this.MakeGridHeader(x => x.ActiveFlag),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<GoodsInput_View> GetSearchQuery()
        {
            var query = DC.Set<GoodsInput>()
                .CheckEqual(Searcher.GoodsInfoId, x=>x.GoodsInfoId)
                .CheckEqual(Searcher.ActiveFlag, x=>x.ActiveFlag)
                .Select(x => new GoodsInput_View
                {
				    ID = x.ID,
                    InputTime = x.InputTime,
                    SupplierName_view = x.Supplier.SupplierName,
                    GoodsName_view = x.GoodsInfo.GoodsName,
                    Producer = x.Producer,
                    BatchNumber = x.BatchNumber,
                    ApprovalNo = x.ApprovalNo,
                    ActiveFlag = x.ActiveFlag,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GoodsInput_View : GoodsInput{
        [Display(Name = "供应商名称")]
        public String SupplierName_view { get; set; }
        [Display(Name = "商品名称")]
        public String GoodsName_view { get; set; }

    }
}
