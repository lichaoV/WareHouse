using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public class GoodsInfo : PersistPoco
    {
        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "{0}required")]
        public string GoodsName { get; set; }

        [Display(Name = "商品描述")]
        public string GoodsDesc { get; set; }

        [Display(Name = "规格")]
        [Required(ErrorMessage = "{0}required")]
        public string Specification { get; set; }

        [Display(Name = "销售价格")]
        [Required(ErrorMessage = "{0}required")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "库存")]
        [Required(ErrorMessage = "{0}required")]
        public int InputNumber { get; set; }

        [Display(Name = "预警值")]
        [Required(ErrorMessage = "{0}required")]
        public int WarningValue { get; set; }

        [Display(Name = "所属仓库")]
        [Required(ErrorMessage = "{0}required")]
        public Guid StoreHouseId { get; set; }

        [Display(Name = "所属仓库")]
        public StoreHouse StoreHouse { get; set; }

        [Display(Name = "商品图片")]
        public Guid? PhotoId { get; set; }

        [Display(Name = "Photo")]
        public FileAttachment Photo { get; set; }
    }
}
