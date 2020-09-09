using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelCalculator
{
    public class Calculator : ICalculator
    {
        protected ILogging logger;
        private readonly CalculatorRuleParams calParams;
        public Calculator(CalculatorRuleParams calParams, ILogging logger)
        {
            this.logger = logger;
            this.calParams = calParams;
        }

        public void SetParcelTypeAndRate(Parcel parcel)
        {
            try
            {
                if (parcel.Weight > calParams.MaxAllowedWeight)
                    parcel.TypeOfTheParcel = ParcelType.OverWeighted;
                else if (parcel.Weight > calParams.MaxWeightForVolumeCalculator)
                {
                    parcel.TypeOfTheParcel = ParcelType.Heavy;
                    parcel.Rate = calParams.HeavyParcelRate;
                }
                else if (parcel.Volume >= calParams.MinVolumeForLargeParcel)
                {
                    parcel.TypeOfTheParcel = ParcelType.Large;
                    parcel.Rate = calParams.LargeParcelRate;
                }
                else if (parcel.Volume >= calParams.MinVolumeForMediumParcel)
                {
                    parcel.TypeOfTheParcel = ParcelType.Medium;
                    parcel.Rate = calParams.MediumParcelRate;
                }
                else
                {
                    parcel.TypeOfTheParcel = ParcelType.Small;
                    parcel.Rate = calParams.SmallParcelRate;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog("Error happened during setting parcel type and rate. Exception Msg: {0}; Inner exception: {1}", new string[] { ex.Message, ex.InnerException.ToString() });
                throw (ex);
            }
        }
        public CalculationResult CalculatePrice(Parcel parcel)
        {
            var calculationResult = new CalculationResult(0, false, false);
            try
            {
                if (parcel.TypeOfTheParcel == ParcelType.OverWeighted)
                {
                    calculationResult.IsOverWeighted = true;
                }
                else if (parcel.TypeOfTheParcel == ParcelType.Heavy)
                {
                    calculationResult.Price = Math.Round(parcel.Weight * parcel.Rate, 2);
                }
                else
                    calculationResult.Price = Math.Round(parcel.Volume * parcel.Rate, 2);

                calculationResult.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                logger.WriteLog("Error happened during calculating price. Exception Msg: {0}; Inner exception: {1}", new string[] { ex.Message, ex.InnerException.ToString() });
                calculationResult.IsSuccessful = false;
            }

            return calculationResult;
        }
    }
}
