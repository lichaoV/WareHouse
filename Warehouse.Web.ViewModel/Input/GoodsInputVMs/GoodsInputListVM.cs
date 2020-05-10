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
                this.MakeGridHeader(x => x.GoodsName),
                this.MakeGridHeader(x => x.GoodsDesc),
                this.MakeGridHeader(x => x.Producer),
                this.MakeGridHeader(x => x.Specification),
                this.MakeGridHeader(x => x.BatchNumber),
                this.MakeGridHeader(x => x.ApprovalNo),
                this.MakeGridHeader(x => x.SellingPrice),
                this.MakeGridHeader(x => x.InputNumber),
                this.MakeGridHeader(x => x.WarningValue),
                this.MakeGridHeader(x => x.ActiveFlag),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(GoodsInput_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<GoodsInput_View> GetSearchQuery()
        {
            var query = DC.Set<GoodsInput>()
                .CheckBetween(Searcher.InputTime?.GetStartTime(), Searcher.InputTime?.GetEndTime(), x => x.InputTime, includeMax: false)
                .CheckContain(Searcher.GoodsName, x=>x.GoodsName)
                .CheckEqual(Searcher.ActiveFlag, x=>x.ActiveFlag)
                .Select(x => new GoodsInput_View
                {
				    ID = x.ID,
                    InputTime = x.InputTime,
                    SupplierName_view = x.Supplier.SupplierName,
                    GoodsName = x.GoodsName,
                    GoodsDesc = x.GoodsDesc,
                    Producer = x.Producer,
                    Specification = x.Specification,
                    BatchNumber = x.BatchNumber,
                    ApprovalNo = x.ApprovalNo,
                    SellingPrice = x.SellingPrice,
                    InputNumber = x.InputNumber,
                    WarningValue = x.WarningValue,
                    ActiveFlag = x.ActiveFlag,
                    PhotoId = x.PhotoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GoodsInput_View : GoodsInput{
        [Display(Name = "供应商名称")]
        public String SupplierName_view { get; set; }

    }
}
