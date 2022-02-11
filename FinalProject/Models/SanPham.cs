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
    
    public partial class SanPham
    {
        public SanPham()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public string ProductID { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public string ThuongHieu { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public Nullable<long> SoLuong { get; set; }
        public string image { get; set; }
    
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}