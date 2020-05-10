using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Output.SaleOutputVMs
{
    public partial class SaleOutputVM : BaseCRUDVM<SaleOutput>
    {
        public List<ComboSelectListItem> AllCustomers { get; set; }
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }

        public SaleOutputVM()
        {
            SetInclude(x => x.Customer);
            SetInclude(x => x.GoodsInfo);
        }

        protected override void InitVM()
        {
            AllCustomers = DC.Set<Customer>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CustomerName);
            AllGoodsInfos = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName);
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
