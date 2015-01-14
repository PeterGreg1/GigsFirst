using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("Vendors")]
    public class Vendor
    {
        public Vendor()
        {
            this.ShowVendors = new HashSet<ShowVendor>();
        }

        [Key]
        public int VendorID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ShowVendor> ShowVendors { get; set; }
    }
}
