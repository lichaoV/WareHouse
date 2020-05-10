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
    public partial class SupplierSearcher : BaseSearcher
    {
        [Display(Name = "供应商名称")]
        public String SupplierName { get; set; }
        [Display(Name = "供应商电话")]
        public String SupplierPhone { get; set; }
        [Display(Name = "联系人")]
        public String Contract { get; set; }
        [Display(Name = "联系电话")]
        public String ContractPhone { get; set; }

        protected override void InitVM()
        {
        }

    }
}
