//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.KhachHangs = new HashSet<KhachHang>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public long OrderID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string Status { get; set; }
    
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
