using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.StoreHouseVMs
{
    public partial class StoreHouseListVM : BasePagedListVM<StoreHouse_View, StoreHouseSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.Create, "新建","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.Edit, "修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.Delete, "删除", "Basic",dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.Details, "详细","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.BatchEdit, "批量修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.BatchDelete, "批量删除","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.Import, "导入","Basic", dialogWidth: 800),
                this.MakeStandardAction("StoreHouse", GridActionStandardTypesEnum.ExportExcel, "导出","Basic"),
            };
        }

        protected override IEnumerable<IGridColumn<StoreHouse_View>> InitGridHeader()
        {
            return new List<GridColumn<StoreHouse_View>>{
                this.MakeGridHeader(x => x.WarehouseCode),
                this.MakeGridHeader(x => x.WarehouseAddress),
                this.MakeGridHeader(x => x.ContractName),
                this.MakeGridHeader(x => x.ContractPhone),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<StoreHouse_View> GetSearchQuery()
        {
            var query = DC.Set<StoreHouse>()
                .CheckContain(Searcher.WarehouseCode, x=>x.WarehouseCode)
                .CheckContain(Searcher.ContractName, x=>x.ContractName)
                .Select(x => new StoreHouse_View
                {
				    ID = x.ID,
                    WarehouseCode = x.WarehouseCode,
                    WarehouseAddress = x.WarehouseAddress,
                    ContractName = x.ContractName,
                    ContractPhone = x.ContractPhone,
                    Remark = x.Remark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class StoreHouse_View : StoreHouse{

    }
}
