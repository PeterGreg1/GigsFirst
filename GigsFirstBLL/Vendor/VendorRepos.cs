using System.Collections.Generic;
using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class VendorRepos : BasicCrud<Vendor>, IVendorRepos
    {
        public List<Vendor> GetShowVendorsByShowId(int showid)
        {
            List<Vendor> vendors = new List<Vendor>();

            vendors = (List<Vendor>)(from s in Db.ShowVendors where s.ShowId == showid select s.Vendor).ToList();

            return FilterActiveAndNotDeleted(vendors);
        }

        private List<Vendor> FilterActiveAndNotDeleted(List<Vendor> vendors)
        {

            vendors = (List<Vendor>)(from v in vendors
                                 where
                                     v.Active == true &&
                                     v.Deleted == false
                                 select v).ToList();

            return vendors;
        }
    }
}
