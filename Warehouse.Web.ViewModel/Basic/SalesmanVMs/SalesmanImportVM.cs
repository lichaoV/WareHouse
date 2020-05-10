using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.SalesmanVMs
{
    public partial class SalesmanTemplateVM : BaseTemplateVM
    {
        [Display(Name = "销售员姓名")]
        public ExcelPropety SalesmanName_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.SalesmanName);
        [Display(Name = "销售员编号")]
        public ExcelPropety SalesmanCode_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.SalesmanCode);
        [Display(Name = "销售员电话")]
        public ExcelPropety SalesmanPhone_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.SalesmanPhone);
        [Display(Name = "入职时间")]
        public ExcelPropety EntryTime_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.EntryTime);
        [Display(Name = "离职时间")]
        public ExcelPropety QuitTime_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.QuitTime);
        [Display(Name = "性别")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.Sex);
        [Display(Name = "是否离职")]
        public ExcelPropety ActiveFlag_Excel = ExcelPropety.CreateProperty<Salesman>(x => x.ActiveFlag);

	    protected override void InitVM()
        {
        }

    }

    public class SalesmanImportVM : BaseImportVM<SalesmanTemplateVM, Salesman>
    {

    }

}
