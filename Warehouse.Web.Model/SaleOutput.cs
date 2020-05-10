using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Warehouse.Web.Model
{
    public enum PayTypeEnum
    {
        [Display(Name = "支付宝")]
        支付宝 = 0,
        [Display(Name = "微信")]
        微信 = 1,
        [Display(Name = "银联")]
        银联 = 2
    }

    public class SaleOutput : PersistPoco
    {
        [Display(Name = "销售员")]
        [Required(ErrorMessage = "{0}required")]
        public Guid SalesmanId { get; set; }

        [Display(Name = "销售员")]
        public Salesman Salesman { get; set; }

        [Display(Name = "销售时间")]
        [Required(ErrorMessage = "{0}required")]
        public DateTime SaleTime { get; set; }

        [Display(Name = "客户名称")]
        [Required(ErrorMessage = "{0}required")]
        public Guid CustomerId { get; set; }

        [Display(Name = "客户名称")]
        public Customer Customer { get; set; }

        [Display(Name = "商品名称")]
        [Required(ErrorMessage = "{0}required")]
        public Guid? GoodsInfoId { get; set; }

        public GoodsInfo GoodsInfo { get; set; }

        [Display(Name = "销售数量")]
        [Required(ErrorMessage = "{0}required")]
        public int SaleNumber { get; set; }

        [Display(Name = "销售价格")]
        [Required(ErrorMessage = "{0}required")]
        public decimal SalePrice { get; set; }

        [Display(Name = "支付类型")]
        [Required(ErrorMessage = "{0}required")]
        public PayTypeEnum PayType { get; set; }

        [Display(Name = "销售备注")]
        public string SaleRemark { get; set; }
    }
}
