using System;
using System.Collections.Specialized;
using System.Configuration;


namespace ParcelCalculator
{
    public class CalculatorRuleParams
    {
        private readonly ILogging logger;

        private readonly string keyOfMaxAllowedWeight = "maxAllowedWeight";
        private readonly string keyOfMaxWeightForVolumeCalculator = "maxWeightForVolumeCalculator";
        private readonly string keyOfMinVolumeForMediumParcel = "minVolumeForMediumParcel";
        private readonly string keyOfMinVolumeForLargeParcel = "minVolumeForLargeParcel";
        private readonly string keyOfHeavyParcelRate = "heavyParcelRate";
        private readonly string keyOfSmallParcelRate = "smallParcelRate";
        private readonly string keyOfMediumParcelRate = "mediumParcelRate";
        private readonly string keyOfLargeParcelRate = "largeParcelRate";

        public int MaxAllowedWeight { get; set; }
        public int MaxWeightForVolumeCalculator { get; set; }
        public int MinVolumeForMediumParcel { get; set; }
        public int MinVolumeForLargeParcel { get; set; }
        public double HeavyParcelRate { get; set; }
        public double SmallParcelRate { get; set; }
        public double MediumParcelRate { get; set; }
        public double LargeParcelRate { get; set; }

        public CalculatorRuleParams()
        {
        }

        public CalculatorRuleParams(ILogging logger, NameValueCollection collection)
        {
            this.logger = logger;

            MaxAllowedWeight = (int)GetValueFromConfig(keyOfMaxAllowedWeight, collection);
            MaxWeightForVolumeCalculator = (int)GetValueFromConfig(keyOfMaxWeightForVolumeCalculator, collection);

            MinVolumeForMediumParcel = (int)GetValueFromConfig(keyOfMinVolumeForMediumParcel, collection);
            MinVolumeForLargeParcel = (int)GetValueFromConfig(keyOfMinVolumeForLargeParcel, collection);

            HeavyParcelRate = GetValueFromConfig(keyOfHeavyParcelRate, collection);
            SmallParcelRate = GetValueFromConfig(keyOfSmallParcelRate, collection);
            MediumParcelRate = GetValueFromConfig(keyOfMediumParcelRate, collection);
            LargeParcelRate = GetValueFromConfig(keyOfLargeParcelRate, collection);
        }

        public double GetValueFromConfig(string keyString, NameValueCollection applicationSettings)
        {
            double paramValue = 0;
            
            try
            {
                paramValue = double.Parse(applicationSettings[keyString]);
            }
            catch (Exception ex)
            {
                logger.WriteLog("Error occured while loading applicaiton settings. Can not convert value: '{0}' for key: '{1}' to a double.", new string[] { applicationSettings[keyString], keyString });
                throw (ex);
            }
          
            return paramValue;
        }
    }
}
