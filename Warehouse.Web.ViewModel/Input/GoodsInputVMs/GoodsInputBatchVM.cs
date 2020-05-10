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
    public partial class GoodsInputBatchVM : BaseBatchVM<GoodsInput, GoodsInput_BatchEdit>
    {
        public GoodsInputBatchVM()
        {
            ListVM = new GoodsInputListVM();
            LinkedVM = new GoodsInput_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class GoodsInput_BatchEdit : BaseVM
    {
        [Display(Name = "销售价格")]
        public Decimal? SellingPrice { get; set; }
        [Display(Name = "预警值")]
        public Int32? WarningValue { get; set; }

        protected override void InitVM()
        {
        }

    }

}
