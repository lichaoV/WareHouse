using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public class Customer : PersistPoco
    {
        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "{0}required")]
        public string CustomerName { get; set; }

        [Display(Name = "客户地址")]
        public string CustomerAddress { get; set; }

        [Display(Name = "客户电话")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "{0}formaterror")]
        public string CustomerPhone { get; set; }

        [Display(Name = "邮编")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "{0}formaterror")]
        public string ZipCode { get; set; }

        [Display(Name = "联系人")]
        [Required(ErrorMessage = "{0}required")]
        public string Contract { get; set; }

        [Display(Name = "联系人电话")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "{0}formaterror")]
        [Required(ErrorMessage = "{0}required")]
        public string ContractPhone { get; set; }

        [Display(Name = "开户银行")]
        public string DepositBank { get; set; }

        [Display(Name = "银行账户")]
        [RegularExpression("^/^([1-9]{1})(\\d{14}|\\d{18})$/", ErrorMessage = "{0}formaterror")]
        public string BankAccount { get; set; }

    }
}
