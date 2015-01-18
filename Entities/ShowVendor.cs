using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ShowVendors")]
    public partial class ShowVendor : GigsFirstEntity
    {
        [Key]
        public int ShowVendorId { get; set; }
        public int VendorId { get; set; }
        public int ShowId { get; set; }
        public string VendorRefCode { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid? AddedBy { get; set; }

        public virtual Show Show { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
