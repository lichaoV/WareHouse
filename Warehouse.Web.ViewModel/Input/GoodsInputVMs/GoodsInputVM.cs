using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Input.GoodsInputVMs
{
    public partial class GoodsInputVM : BaseCRUDVM<GoodsInput>
    {
        public List<ComboSelectListItem> AllSuppliers { get; set; }
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }

        public GoodsInputVM()
        {
            SetInclude(x => x.Supplier);
            SetInclude(x => x.GoodsInfo);
        }

        protected override void InitVM()
        {
            AllSuppliers = DC.Set<Supplier>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SupplierName);
            AllGoodsInfos = DC.Set<GoodsInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GoodsName + "   " + y.Specification + "   " + GetStoreName(y.StoreHouseId));
        }

        public string GetStoreName(Guid StoreHouseId)
        {
            string StoreHouseName = string.Empty;

            string sql = "SELECT * FROM StoreHouse WHERE ID='{0}'";
            sql = string.Format(sql, StoreHouseId);
            DataTable dt = DC.RunSQL(sql);
            if (dt.Rows.Count > 0)
            {
                StoreHouseName = dt.Rows[0]["WarehouseCode"].ToString();
            }
            return StoreHouseName;
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
