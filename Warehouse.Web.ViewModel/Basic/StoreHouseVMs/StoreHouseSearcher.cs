using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.StoreHouseVMs
{
    public partial class StoreHouseSearcher : BaseSearcher
    {
        [Display(Name = "仓库编号")]
        public String WarehouseCode { get; set; }
        [Display(Name = "负责人")]
        public String ContractName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
