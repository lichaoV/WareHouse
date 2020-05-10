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
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }
        public Guid? GoodsInfoId { get; set; }
        [Display(Name = "是否可用")]
        public Boolean? ActiveFlag { get; set; }

        protected override void InitVM()
        {
            AllGoodsInfos = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
        }

    }
}
