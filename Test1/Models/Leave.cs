//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Leave
    {
        public int Id { get; set; }
        public Nullable<int> empid { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> startdate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> enddate { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
    }
}
