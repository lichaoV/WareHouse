using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Input.GoodsInputVMs
{
    public partial class GoodsInputTemplateVM : BaseTemplateVM
    {
        [Display(Name = "入库时间")]
        public ExcelPropety InputTime_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.InputTime);
        [Display(Name = "供应商")]
        public ExcelPropety Supplier_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.SupplierId);
        [Display(Name = "商品名称")]
        public ExcelPropety GoodsInfo_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.GoodsInfoId);
        [Display(Name = "入库数量")]
        public ExcelPropety InputNumber_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.InputNumber);
        [Display(Name = "产地")]
        public ExcelPropety Producer_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.Producer);
        [Display(Name = "生产批号")]
        public ExcelPropety BatchNumber_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.BatchNumber);
        [Display(Name = "批准文号")]
        public ExcelPropety ApprovalNo_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.ApprovalNo);

	    protected override void InitVM()
        {
            Supplier_Excel.DataType = ColumnDataType.ComboBox;
            Supplier_Excel.ListItems = DC.Set<Supplier>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SupplierName);
            GoodsInfo_Excel.DataType = ColumnDataType.ComboBox;
            GoodsInfo_Excel.ListItems = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
        }

    }

    public class GoodsInputImportVM : BaseImportVM<GoodsInputTemplateVM, GoodsInput>
    {

    }

}
