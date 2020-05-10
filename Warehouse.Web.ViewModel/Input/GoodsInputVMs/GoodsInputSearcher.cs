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
    public partial class GoodsInputSearcher : BaseSearcher
    {
        [Display(Name = "入库时间")]
        public DateRange InputTime { get; set; }
        [Display(Name = "商品名称")]
        public String GoodsName { get; set; }
        [Display(Name = "是否可用")]
        public Boolean? ActiveFlag { get; set; }

        protected override void InitVM()
        {
        }

    }
}
