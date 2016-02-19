using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Package
    {
        private List<AsPurchasedItem> apitems;
        public virtual int PackageID { get; set; }
        public virtual decimal  PackageCost { get; set; }

        public List<AsPurchasedItem> APItems 
        {
            get { return apitems ; }
            set { apitems = value; } 
        }


    }
}