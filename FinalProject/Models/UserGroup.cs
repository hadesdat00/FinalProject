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
    
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.Users = new HashSet<User>();
        }
    
        public string MaGroup { get; set; }
        public string TenGroup { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
