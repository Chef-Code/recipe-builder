using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.ModelMetaData
{
    public class FoodMetaData
    {
        public int FoodID;

        public string FoodName;
        public string Specification;
        public string SpecificFoodName;
        [Display(Name = "Single Item Weight")]
        public decimal IndividualAsPurchasedWeight;
        public decimal YieldPercentage;
        public decimal EdiblePortion;
        public decimal Waste;
        public bool PotentiallyHazardous;
    }
}