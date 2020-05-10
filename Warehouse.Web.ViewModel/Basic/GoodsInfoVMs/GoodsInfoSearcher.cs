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
        public List<ComboSelectListItem> AllStoreHouses { get; set; }
        [Display(Name = "所属仓库")]
        public Guid? StoreHouseId { get; set; }

        protected override void InitVM()
        {
            AllStoreHouses = DC.Set<StoreHouse>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ContractName);
        }

    }
}
