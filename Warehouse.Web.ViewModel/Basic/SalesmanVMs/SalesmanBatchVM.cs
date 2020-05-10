using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;


namespace Warehouse.Web.ViewModel.Basic.SalesmanVMs
{
    public partial class SalesmanBatchVM : BaseBatchVM<Salesman, Salesman_BatchEdit>
    {
        public SalesmanBatchVM()
        {
            ListVM = new SalesmanListVM();
            LinkedVM = new Salesman_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class Salesman_BatchEdit : BaseVM
    {
        [Display(Name = "入职时间")]
        public DateRange EntryTime { get; set; }
        [Display(Name = "离职时间")]
        public DateRange QuitTime { get; set; }

        protected override void InitVM()
        {
        }

    }

}
