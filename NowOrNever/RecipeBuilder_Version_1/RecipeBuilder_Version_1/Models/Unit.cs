using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    [NotMapped]
    public class Unit
    {
        string[] _units = new string[2] { "Pound", "Ounce" };
        public string this[int index]
        { 
            get
            {
                string tmp = "";

                if(index >= 0 || index <= _units.Length)
                {
                    tmp = _units[index];
                    return (tmp);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }                         
        }

        public decimal Value { get; set; }

    }
    public class Cup
    {

    }
    public class UnitConversion
    {
        
    }
}