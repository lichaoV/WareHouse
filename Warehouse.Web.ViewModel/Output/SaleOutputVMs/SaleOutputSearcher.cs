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
        public List<ComboSelectListItem> AllSalesmans { get; set; }
        [Display(Name = "销售员")]
        public Guid? SalesmanId { get; set; }
        public List<ComboSelectListItem> AllCustomers { get; set; }
        [Display(Name = "客户名称")]
        public Guid? CustomerId { get; set; }
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }
        public Guid? GoodsInfoId { get; set; }

        protected override void InitVM()
        {
            AllSalesmans = DC.Set<Salesman>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SalesmanName);
            AllCustomers = DC.Set<Customer>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CustomerName);
            AllGoodsInfos = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
        }

    }
}
