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
    public partial class GoodsInputBatchVM : BaseBatchVM<GoodsInput, GoodsInput_BatchEdit>
    {
        public GoodsInputBatchVM()
        {
            ListVM = new GoodsInputListVM();
            LinkedVM = new GoodsInput_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class GoodsInput_BatchEdit : BaseVM
    {
        public List<ComboSelectListItem> AllSuppliers { get; set; }
        [Display(Name = "供应商")]
        public Guid? SupplierId { get; set; }
        [Display(Name = "产地")]
        public String Producer { get; set; }
        [Display(Name = "生产批号")]
        public String BatchNumber { get; set; }
        [Display(Name = "批准文号")]
        public String ApprovalNo { get; set; }

        protected override void InitVM()
        {
            AllSuppliers = DC.Set<Supplier>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.SupplierName);
        }

    }

}
