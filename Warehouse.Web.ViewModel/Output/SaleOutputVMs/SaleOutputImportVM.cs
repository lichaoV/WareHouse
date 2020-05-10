using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Output.SaleOutputVMs
{
    public partial class SaleOutputTemplateVM : BaseTemplateVM
    {
        [Display(Name = "销售时间")]
        public ExcelPropety SaleTime_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.SaleTime);
        [Display(Name = "客户名称")]
        public ExcelPropety Customer_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.CustomerId);
        [Display(Name = "商品名称")]
        public ExcelPropety GoodsInfo_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.GoodsInfoId);
        [Display(Name = "销售数量")]
        public ExcelPropety SaleNumber_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.SaleNumber);
        [Display(Name = "销售价格")]
        public ExcelPropety SalePrice_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.SalePrice);
        [Display(Name = "支付类型")]
        public ExcelPropety PayType_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.PayType);
        [Display(Name = "销售备注")]
        public ExcelPropety SaleRemark_Excel = ExcelPropety.CreateProperty<SaleOutput>(x => x.SaleRemark);

	    protected override void InitVM()
        {
            Customer_Excel.DataType = ColumnDataType.ComboBox;
            Customer_Excel.ListItems = DC.Set<Customer>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CustomerName);
            GoodsInfo_Excel.DataType = ColumnDataType.ComboBox;
            GoodsInfo_Excel.ListItems = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
        }

    }

    public class SaleOutputImportVM : BaseImportVM<SaleOutputTemplateVM, SaleOutput>
    {

    }

}
