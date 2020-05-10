using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.SalesmanVMs
{
    public partial class SalesmanListVM : BasePagedListVM<Salesman_View, SalesmanSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.Create, "新建","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.Edit, "修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.Delete, "删除", "Basic",dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.Details, "详细","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.BatchEdit, "批量修改","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.BatchDelete, "批量删除","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.Import, "导入","Basic", dialogWidth: 800),
                this.MakeStandardAction("Salesman", GridActionStandardTypesEnum.ExportExcel, "导出","Basic"),
            };
        }

        protected override IEnumerable<IGridColumn<Salesman_View>> InitGridHeader()
        {
            return new List<GridColumn<Salesman_View>>{
                this.MakeGridHeader(x => x.SalesmanName),
                this.MakeGridHeader(x => x.SalesmanCode),
                this.MakeGridHeader(x => x.SalesmanPhone),
                this.MakeGridHeader(x => x.EntryTime),
                this.MakeGridHeader(x => x.QuitTime),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.ActiveFlag),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(Salesman_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<Salesman_View> GetSearchQuery()
        {
            var query = DC.Set<Salesman>()
                .CheckContain(Searcher.SalesmanName, x=>x.SalesmanName)
                .CheckContain(Searcher.SalesmanCode, x=>x.SalesmanCode)
                .CheckBetween(Searcher.EntryTime?.GetStartTime(), Searcher.EntryTime?.GetEndTime(), x => x.EntryTime, includeMax: false)
                .CheckBetween(Searcher.QuitTime?.GetStartTime(), Searcher.QuitTime?.GetEndTime(), x => x.QuitTime, includeMax: false)
                .CheckEqual(Searcher.Sex, x=>x.Sex)
                .CheckEqual(Searcher.ActiveFlag, x=>x.ActiveFlag)
                .Select(x => new Salesman_View
                {
				    ID = x.ID,
                    SalesmanName = x.SalesmanName,
                    SalesmanCode = x.SalesmanCode,
                    SalesmanPhone = x.SalesmanPhone,
                    EntryTime = x.EntryTime,
                    QuitTime = x.QuitTime,
                    Sex = x.Sex,
                    ActiveFlag = x.ActiveFlag,
                    PhotoId = x.PhotoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Salesman_View : Salesman{

    }
}
