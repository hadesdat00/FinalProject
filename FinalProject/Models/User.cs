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
    
    public partial class User
    {
        public User()
        {
            this.KhachHangs = new HashSet<KhachHang>();
        }
    
        public string MaUser { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string MaGroup { get; set; }
    
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
