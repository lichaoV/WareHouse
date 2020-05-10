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
    public partial class StoreHouseBatchVM : BaseBatchVM<StoreHouse, StoreHouse_BatchEdit>
    {
        public StoreHouseBatchVM()
        {
            ListVM = new StoreHouseListVM();
            LinkedVM = new StoreHouse_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class StoreHouse_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
