//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiupviecPalmy_com.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupNew
    {
        public GroupNew()
        {
            this.News = new HashSet<News>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Tag { get; set; }
        public string Level { get; set; }
        public bool Index { get; set; }
        public bool Priority { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<News> News { get; set; }
    }
}
