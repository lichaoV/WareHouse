using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Warehouse.Web.Model;
using SexEnum = Warehouse.Web.Model.SexEnum;

namespace Warehouse.Web.ViewModel.Basic.SalesmanVMs
{
    public partial class SalesmanSearcher : BaseSearcher
    {
        [Display(Name = "销售员姓名")]
        public String SalesmanName { get; set; }
        [Display(Name = "销售员编号")]
        public String SalesmanCode { get; set; }
        [Display(Name = "入职时间")]
        public DateRange EntryTime { get; set; }
        [Display(Name = "离职时间")]
        public DateRange QuitTime { get; set; }
        [Display(Name = "性别")]
        public SexEnum? Sex { get; set; }
        [Display(Name = "是否离职")]
        public Boolean? ActiveFlag { get; set; }

        protected override void InitVM()
        {
        }

    }
}
