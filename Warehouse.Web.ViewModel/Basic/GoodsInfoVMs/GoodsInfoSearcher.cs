using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.GoodsInfoVMs
{
    public partial class GoodsInfoSearcher : BaseSearcher
    {
        [Display(Name = "商品名称")]
        public String GoodsName { get; set; }
        [Display(Name = "规格")]
        public String Specification { get; set; }

        protected override void InitVM()
        {
        }

    }
}
