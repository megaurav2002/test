using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelCalculator
{
    public class CalculationResult
    {
        public double Price { get; set; }
        public bool IsSuccessful { get; set; }

        public bool IsOverWeighted { get; set; }

        public CalculationResult(){
            Price = 0;
            IsSuccessful = false;
            IsOverWeighted = false;
        }
        public CalculationResult(double price, bool isSuccessful, bool isOverWeighted)
        {
            Price = price;
            IsSuccessful = isSuccessful;
            IsOverWeighted = isOverWeighted;
        }
    }
}
