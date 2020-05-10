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
    public partial class SaleOutputBatchVM : BaseBatchVM<SaleOutput, SaleOutput_BatchEdit>
    {
        public SaleOutputBatchVM()
        {
            ListVM = new SaleOutputListVM();
            LinkedVM = new SaleOutput_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class SaleOutput_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
