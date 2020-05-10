using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.StoreHouseVMs
{
    public partial class StoreHouseTemplateVM : BaseTemplateVM
    {
        [Display(Name = "仓库编号")]
        public ExcelPropety WarehouseCode_Excel = ExcelPropety.CreateProperty<StoreHouse>(x => x.WarehouseCode);
        [Display(Name = "仓库地址")]
        public ExcelPropety WarehouseAddress_Excel = ExcelPropety.CreateProperty<StoreHouse>(x => x.WarehouseAddress);
        [Display(Name = "负责人")]
        public ExcelPropety ContractName_Excel = ExcelPropety.CreateProperty<StoreHouse>(x => x.ContractName);
        [Display(Name = "联系电话")]
        public ExcelPropety ContractPhone_Excel = ExcelPropety.CreateProperty<StoreHouse>(x => x.ContractPhone);
        [Display(Name = "备注")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<StoreHouse>(x => x.Remark);

	    protected override void InitVM()
        {
        }

    }

    public class StoreHouseImportVM : BaseImportVM<StoreHouseTemplateVM, StoreHouse>
    {

    }

}
