using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class FoodItem
    {
        private decimal _yieldPercentage;
        //private decimal _waste;
        public int FoodItemID { get; set; }
        public string FoodName { get; set; }  //Shrimp
        public string Specification { get; set; } //16-20 (individual shrimp) to a pound
        public string SpecificFoodName
        {
            get { return String.Format("{0} {1}", FoodName, Specification); }
        }
        public decimal IndividualAsPurchasedWeight { get; set; }
        //public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal YieldPercentage
        {
            get { return _yieldPercentage; }
            set
            {
                if (YieldPercentage >= 0.00m && YieldPercentage <= 1.00m)
                    _yieldPercentage = value;
            }
        }
        public decimal EdiblePortion
        { 
            get 
            {
                decimal _actual = Decimal.Multiply(IndividualAsPurchasedWeight, YieldPercentage);

                return _actual;
            } 
        }
        public decimal Waste
        {
            set
            {
                decimal actual = Decimal.Multiply(IndividualAsPurchasedWeight, YieldPercentage);
                decimal _waste = Decimal.Subtract(IndividualAsPurchasedWeight, actual);

                _waste = value;
            }
        }
        //Potentially Hazardous Foods
        public bool PotentiallyHazardous { get; set; }
    }
}