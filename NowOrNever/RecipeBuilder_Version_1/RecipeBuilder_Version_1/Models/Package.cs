using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Package
    {
        public Package()
        {
            this.AsPurchasedItem = new AsPurchasedItem();
        }
        public int PackageID { get; set; }
        public decimal  PackageCost { get; set; }
        public string VendorCode { get; set; }
        public string QRCode { get; set; } //Quick Response Code

        public int AsPurchasedItemID { get; set; }
        public virtual AsPurchasedItem AsPurchasedItem { get; set; }
        //public virtual ICollection<AsPurchasedItem> AsPurchasedItems { get; set; }
    }
}