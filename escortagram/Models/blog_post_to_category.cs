//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace escortagram.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog_post_to_category
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int post_id { get; set; }
    
        public virtual blog_category blog_category { get; set; }
        public virtual blog_post blog_post { get; set; }
    }
}
