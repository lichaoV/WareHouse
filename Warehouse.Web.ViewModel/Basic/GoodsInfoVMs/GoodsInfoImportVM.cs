using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.GoodsInfoVMs
{
    public partial class GoodsInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "商品名称")]
        public ExcelPropety GoodsName_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.GoodsName);
        [Display(Name = "商品描述")]
        public ExcelPropety GoodsDesc_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.GoodsDesc);
        [Display(Name = "规格")]
        public ExcelPropety Specification_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.Specification);
        [Display(Name = "销售价格")]
        public ExcelPropety SellingPrice_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.SellingPrice);
        [Display(Name = "库存")]
        public ExcelPropety InputNumber_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.InputNumber);
        [Display(Name = "预警值")]
        public ExcelPropety WarningValue_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.WarningValue);
        [Display(Name = "所属仓库")]
        public ExcelPropety StoreHouse_Excel = ExcelPropety.CreateProperty<GoodsInfo>(x => x.StoreHouseId);

	    protected override void InitVM()
        {
            StoreHouse_Excel.DataType = ColumnDataType.ComboBox;
            StoreHouse_Excel.ListItems = DC.Set<StoreHouse>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ContractName);
        }

    }

    public class GoodsInfoImportVM : BaseImportVM<GoodsInfoTemplateVM, GoodsInfo>
    {

    }

}
