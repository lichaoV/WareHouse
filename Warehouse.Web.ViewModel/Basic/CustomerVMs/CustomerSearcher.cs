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
    public partial class CustomerSearcher : BaseSearcher
    {
        [Display(Name = "客户名称")]
        public String CustomerName { get; set; }
        [Display(Name = "客户电话")]
        public String CustomerPhone { get; set; }
        [Display(Name = "联系人")]
        public String Contract { get; set; }
        [Display(Name = "联系人电话")]
        public String ContractPhone { get; set; }

        protected override void InitVM()
        {
        }

    }
}
