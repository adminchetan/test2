using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class LocalCollectionMaster

    {

        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> Stateid { get; set; }
        public bool IsActive { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string CollectionCode { get; set; }
        public string Description { get; set; }
        public bool IsUserAvailable { get; set; }
        public string PriceRange { get; set; }
        public string PriceUnit { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CollectionMaster> CollectionMaster1 { get; set; }
        public virtual CollectionMaster CollectionMaster2 { get; set; }
        public virtual DistrictMaster DistrictMaster { get; set; }
        public virtual StateMaster StateMaster { get; set; }
        public virtual Category Category { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }
    }
}