//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryMGRef
    {
        public long CategoryMGRefID { get; set; }
        public long fkMGID { get; set; }
        public long fkCategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual MediaGallery MediaGallery { get; set; }
    }
}
