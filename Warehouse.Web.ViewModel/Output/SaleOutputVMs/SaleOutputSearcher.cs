using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Output.SaleOutputVMs
{
    public partial class SaleOutputSearcher : BaseSearcher
    {
        [Display(Name = "销售时间")]
        public DateRange SaleTime { get; set; }
        public List<ComboSelectListItem> AllCustomers { get; set; }
        [Display(Name = "客户名称")]
        public Guid? CustomerId { get; set; }
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }
        [Display(Name = "商品名称")]
        public Guid? GoodsInfoId { get; set; }
        [Display(Name = "支付类型")]
        public PayTypeEnum? PayType { get; set; }

        protected override void InitVM()
        {
            AllCustomers = DC.Set<Customer>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CustomerName);
            AllGoodsInfos = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
        }

    }
}
