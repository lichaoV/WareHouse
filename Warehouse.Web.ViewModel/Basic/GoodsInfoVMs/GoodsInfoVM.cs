using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.GoodsInfoVMs
{
    public partial class GoodsInfoVM : BaseCRUDVM<GoodsInfo>
    {
        public List<ComboSelectListItem> AllStoreHouses { get; set; }

        public GoodsInfoVM()
        {
            SetInclude(x => x.StoreHouse);
        }

        protected override void InitVM()
        {
            AllStoreHouses = DC.Set<StoreHouse>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.WarehouseCode);
        }

        public override void DoAdd()
        {
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
