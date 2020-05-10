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
        [Display(Name = "供应商")]
        public ExcelPropety Supplier_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.SupplierId);
        [Display(Name = "商品名称")]
        public ExcelPropety GoodsName_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.GoodsName);
        [Display(Name = "商品描述")]
        public ExcelPropety GoodsDesc_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.GoodsDesc);
        [Display(Name = "产地")]
        public ExcelPropety Producer_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.Producer);
        [Display(Name = "规格")]
        public ExcelPropety Specification_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.Specification);
        [Display(Name = "生产批号")]
        public ExcelPropety BatchNumber_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.BatchNumber);
        [Display(Name = "批准文号")]
        public ExcelPropety ApprovalNo_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.ApprovalNo);
        [Display(Name = "销售价格")]
        public ExcelPropety SellingPrice_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.SellingPrice);
        [Display(Name = "入库数量")]
        public ExcelPropety InputNumber_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.InputNumber);
        [Display(Name = "预警值")]
        public ExcelPropety WarningValue_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.WarningValue);
        [Display(Name = "是否可用")]
        public ExcelPropety ActiveFlag_Excel = ExcelPropety.CreateProperty<GoodsInput>(x => x.ActiveFlag);

	    protected override void InitVM()
        {
            Supplier_Excel.DataType = ColumnDataType.ComboBox;
            Supplier_Excel.ListItems = DC.Set<Supplier>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SupplierName);
        }

    }

    public class GoodsInputImportVM : BaseImportVM<GoodsInputTemplateVM, GoodsInput>
    {

    }

}
