using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public enum SexEnum
    {
        [Display(Name = "男")]
        Male = 0,
        [Display(Name = "女")]
        Female = 1
    }

    public class Salesman : PersistPoco
    {
        [Display(Name = "销售员姓名")]
        [Required(ErrorMessage = "{0}required")]
        public string SalesmanName { get; set; }

        [Display(Name = "销售员编号")]
        [Required(ErrorMessage = "{0}required")]
        public string SalesmanCode { get; set; }

        [Display(Name = "销售员电话")]
        [Required(ErrorMessage = "{0}required")]
        public string SalesmanPhone { get; set; }

        [Display(Name = "入职时间")]
        [Required(ErrorMessage = "{0}required")]
        public DateTime EntryTime { get; set; }

        [Display(Name = "离职时间")]
        public DateTime QuitTime { get; set; }

        [Display(Name = "性别")]
        public SexEnum? Sex { get; set; }

        [Display(Name = "是否离职")]
        public bool ActiveFlag { get; set; }

        [Display(Name = "人员照片")]
        public Guid? PhotoId { get; set; }

        [Display(Name = "Photo")]
        public FileAttachment Photo { get; set; }
    }
}
