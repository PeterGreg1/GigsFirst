using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;

namespace GigsFirstBLL
{
    public class VendorRepos : BasicCrud<Vendor>, IVendorRepos
    {
        GigsFirstEntities db = new GigsFirstEntities();

        public List<Vendor> GetShowVendorsByShowID(int showid)
        {
            List<Vendor> vendors = new List<Vendor>();

            vendors = (List<Vendor>)(from s in db.ShowVendors where s.ShowID == showid select s.Vendor).ToList();

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
