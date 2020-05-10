using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Input.GoodsInputVMs
{
    public partial class GoodsInputSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllSuppliers { get; set; }
        [Display(Name = "供应商")]
        public Guid? SupplierId { get; set; }
        public List<ComboSelectListItem> AllGoodsInfos { get; set; }
        [Display(Name = "商品名称")]
        public Guid? GoodsInfoId { get; set; }
        [Display(Name = "产地")]
        public String Producer { get; set; }
        [Display(Name = "生产批号")]
        public String BatchNumber { get; set; }
        [Display(Name = "批准文号")]
        public String ApprovalNo { get; set; }

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
    }
}
