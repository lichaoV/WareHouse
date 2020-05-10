using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public class Supplier: PersistPoco
    {
        [Display(Name = "供应商名称")]
        [Required(ErrorMessage = "{0}required")]
        public string SupplierName { get; set; }

        [Display(Name = "供应商地址")]
        public string SupplierAddress { get; set; }

        [Display(Name = "供应商电话")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "{0}formaterror")]
        public string SupplierPhone { get; set; }

        [Display(Name = "邮编")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "{0}formaterror")]
        public string ZipCode { get; set; }

        [Display(Name = "联系人")]
        [Required(ErrorMessage = "{0}required")]
        public string Contract { get; set; }

        [Display(Name = "联系电话")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "{0}formaterror")]
        [Required(ErrorMessage = "{0}required")]
        public string ContractPhone { get; set; }

        [Display(Name = "开户银行")]
        public string DepositBank { get; set; }

        [Display(Name = "银行账户")]
        public string BankAccount { get; set; }
    }
}
