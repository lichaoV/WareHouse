using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public class GoodsInput : PersistPoco
    {
        [Display(Name = "入库时间")]
        public DateTime? InputTime { get; set; }

        [Display(Name = "供应商")]
        [Required(ErrorMessage = "{0}required")]
        public Guid? SupplierId { get; set; }

        [Display(Name = "供应商")]
        public Supplier Supplier { get; set; }

        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "{0}required")]
        public string GoodsName { get; set; }

        [Display(Name = "商品描述")]
        public string GoodsDesc { get; set; }

        [Display(Name = "产地")]
        [Required(ErrorMessage = "{0}required")]
        public string Producer { get; set; }

        [Display(Name = "规格")]
        [Required(ErrorMessage = "{0}required")]
        public string Specification { get; set; }

        [Display(Name = "生产批号")]
        [Required(ErrorMessage = "{0}required")]
        public string BatchNumber { get; set; }

        [Display(Name = "批准文号")]
        [Required(ErrorMessage = "{0}required")]
        public string ApprovalNo { get; set; }

        [Display(Name = "销售价格")]
        [Required(ErrorMessage = "{0}required")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "入库数量")]
        [Required(ErrorMessage = "{0}required")]
        public int InputNumber { get; set; }

        [Display(Name = "预警值")]
        [Required(ErrorMessage = "{0}required")]
        public int WarningValue { get; set; }

        [Display(Name = "是否可用")]
        public bool ActiveFlag { get; set; }

        [Display(Name = "商品图片")]
        public Guid? PhotoId { get; set; }

        [Display(Name = "Photo")]
        public FileAttachment Photo { get; set; }
    }
}
