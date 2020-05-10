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
    public partial class GoodsInfoBatchVM : BaseBatchVM<GoodsInfo, GoodsInfo_BatchEdit>
    {
        public GoodsInfoBatchVM()
        {
            ListVM = new GoodsInfoListVM();
            LinkedVM = new GoodsInfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class GoodsInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
