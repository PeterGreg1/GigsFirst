using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ShowVendors")]
    public partial class ShowVendor : GigsFirstEntity
    {
        [Key]
        public int ShowVendorID { get; set; }
        public int VendorID { get; set; }
        public int ShowID { get; set; }
        public string VendorRefCode { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public System.DateTime AddedOn { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }

        public virtual Show Show { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
