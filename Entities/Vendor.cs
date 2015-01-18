﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("Vendors")]
    public class Vendor : GigsFirstEntity
    {
        public Vendor()
        {
            this.ShowVendors = new HashSet<ShowVendor>();
        }

        [Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ShowVendor> ShowVendors { get; set; }
    }
}
