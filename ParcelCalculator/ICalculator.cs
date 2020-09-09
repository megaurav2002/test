using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelCalculator
{
    interface ICalculator
    {
        void SetParcelTypeAndRate(Parcel parcel);
        CalculationResult CalculatePrice(Parcel parcel);
    }
}
