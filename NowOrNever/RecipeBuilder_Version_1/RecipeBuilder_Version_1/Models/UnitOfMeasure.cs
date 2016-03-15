using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class UnitOfMeasure
    {
        public int UnitOfMeasureID { get; set; }
        public string Unit { get; set; }
        public decimal UnitQuantity { get; set; }

    }
}