using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecipeBuilder_Version_1.ModelMetaData;

namespace RecipeBuilder_Version_1.Models
{
    [MetadataType(typeof(FoodMetaData))]
    public partial class Food
    {
        private decimal _yieldPercentage;
        public int FoodID { get; set; }
        public string FoodName { get; set; }  //Shrimp
        public string Specification { get; set; } //16-20 (individual shrimp) to a pound
        public Uri URL { get; set; }
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