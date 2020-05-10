using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public class StoreHouse : PersistPoco
    {
        [Display(Name = "仓库编号")]
        [Required(ErrorMessage = "{0}required")]
        public string WarehouseCode { get; set; }

        [Display(Name = "仓库地址")]
        [Required(ErrorMessage = "{0}required")]
        public string WarehouseAddress { get; set; }

        [Display(Name = "负责人")]
        [Required(ErrorMessage = "{0}required")]
        public string ContractName { get; set; }

        [Display(Name = "联系电话")]
        [Required(ErrorMessage = "{0}required")]
        public string ContractPhone { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

    }
}
