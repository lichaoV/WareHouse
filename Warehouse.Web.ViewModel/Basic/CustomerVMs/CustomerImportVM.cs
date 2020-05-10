using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.CustomerVMs
{
    public partial class CustomerTemplateVM : BaseTemplateVM
    {
        [Display(Name = "客户名称")]
        public ExcelPropety CustomerName_Excel = ExcelPropety.CreateProperty<Customer>(x => x.CustomerName);
        [Display(Name = "客户地址")]
        public ExcelPropety CustomerAddress_Excel = ExcelPropety.CreateProperty<Customer>(x => x.CustomerAddress);
        [Display(Name = "客户电话")]
        public ExcelPropety CustomerPhone_Excel = ExcelPropety.CreateProperty<Customer>(x => x.CustomerPhone);
        [Display(Name = "邮编")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<Customer>(x => x.ZipCode);
        [Display(Name = "联系人")]
        public ExcelPropety Contract_Excel = ExcelPropety.CreateProperty<Customer>(x => x.Contract);
        [Display(Name = "联系人电话")]
        public ExcelPropety ContractPhone_Excel = ExcelPropety.CreateProperty<Customer>(x => x.ContractPhone);
        [Display(Name = "开户银行")]
        public ExcelPropety DepositBank_Excel = ExcelPropety.CreateProperty<Customer>(x => x.DepositBank);
        [Display(Name = "银行账户")]
        public ExcelPropety BankAccount_Excel = ExcelPropety.CreateProperty<Customer>(x => x.BankAccount);
        [Display(Name = "是否可用")]
        public ExcelPropety ActiveFlag_Excel = ExcelPropety.CreateProperty<Customer>(x => x.ActiveFlag);

	    protected override void InitVM()
        {
        }

    }

    public class CustomerImportVM : BaseImportVM<CustomerTemplateVM, Customer>
    {

    }

}
