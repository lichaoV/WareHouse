using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Input.GoodsInputVMs
{
    public partial class GoodsInputVM : BaseCRUDVM<GoodsInput>
    {
        public List<ComboSelectListItem> AllSuppliers { get; set; }

        public GoodsInputVM()
        {
            SetInclude(x => x.Supplier);
        }

        protected override void InitVM()
        {
            AllSuppliers = DC.Set<Supplier>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SupplierName);
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
