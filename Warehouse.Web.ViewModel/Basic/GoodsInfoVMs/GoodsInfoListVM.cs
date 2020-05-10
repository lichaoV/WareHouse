using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.GoodsInfoVMs
{
    public partial class GoodsInfoListVM : BasePagedListVM<GoodsInfo_View, GoodsInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.Create, "新建","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.Edit, "修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.Delete, "删除", "Basic",dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.Details, "详细","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.BatchEdit, "批量修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.BatchDelete, "批量删除","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.Import, "导入","Basic", dialogWidth: 800),
                this.MakeStandardAction("GoodsInfo", GridActionStandardTypesEnum.ExportExcel, "导出","Basic"),
            };
        }

        protected override IEnumerable<IGridColumn<GoodsInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<GoodsInfo_View>>{
                this.MakeGridHeader(x => x.GoodsName),
                this.MakeGridHeader(x => x.GoodsDesc),
                this.MakeGridHeader(x => x.Specification),
                this.MakeGridHeader(x => x.SellingPrice),
                this.MakeGridHeader(x => x.InputNumber),
                this.MakeGridHeader(x => x.WarningValue),
                this.MakeGridHeader(x => x.ContractName_view),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(GoodsInfo_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<GoodsInfo_View> GetSearchQuery()
        {
            var query = DC.Set<GoodsInfo>()
                .CheckContain(Searcher.GoodsName, x=>x.GoodsName)
                .CheckEqual(Searcher.StoreHouseId, x=>x.StoreHouseId)
                .Select(x => new GoodsInfo_View
                {
				    ID = x.ID,
                    GoodsName = x.GoodsName,
                    GoodsDesc = x.GoodsDesc,
                    Specification = x.Specification,
                    SellingPrice = x.SellingPrice,
                    InputNumber = x.InputNumber,
                    WarningValue = x.WarningValue,
                    ContractName_view = x.StoreHouse.ContractName,
                    PhotoId = x.PhotoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GoodsInfo_View : GoodsInfo{
        [Display(Name = "负责人")]
        public String ContractName_view { get; set; }

    }
}
