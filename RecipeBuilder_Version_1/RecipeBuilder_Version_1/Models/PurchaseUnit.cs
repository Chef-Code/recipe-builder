using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class PurchaseUnit
    {
        public virtual int PurchaseUnitID { get; set; }
        public virtual  Package PackageItem { get; set; }
    }
}