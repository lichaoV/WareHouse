using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.SupplierVMs
{
    public partial class SupplierTemplateVM : BaseTemplateVM
    {
        [Display(Name = "供应商名称")]
        public ExcelPropety SupplierName_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.SupplierName);
        [Display(Name = "供应商地址")]
        public ExcelPropety SupplierAddress_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.SupplierAddress);
        [Display(Name = "供应商电话")]
        public ExcelPropety SupplierPhone_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.SupplierPhone);
        [Display(Name = "邮编")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.ZipCode);
        [Display(Name = "联系人")]
        public ExcelPropety Contract_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.Contract);
        [Display(Name = "联系电话")]
        public ExcelPropety ContractPhone_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.ContractPhone);
        [Display(Name = "开户银行")]
        public ExcelPropety DepositBank_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.DepositBank);
        [Display(Name = "银行账户")]
        public ExcelPropety BankAccount_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.BankAccount);
        [Display(Name = "是否可用")]
        public ExcelPropety ActiveFlag_Excel = ExcelPropety.CreateProperty<Supplier>(x => x.ActiveFlag);

	    protected override void InitVM()
        {
        }

    }

    public class SupplierImportVM : BaseImportVM<SupplierTemplateVM, Supplier>
    {

    }

}
