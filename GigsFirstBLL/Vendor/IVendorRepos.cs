using System.Collections.Generic;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface IVendorRepos : IBasicCrud<Vendor>
    {
        List<Vendor> GetShowVendorsByShowId(int showid);
    }
}
